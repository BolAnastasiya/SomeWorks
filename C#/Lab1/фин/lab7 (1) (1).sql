Create database Amonic2
use Amonic2

DROP TABLE #csv_temp

CREATE TABLE #csv_temp(
	User_Role nvarchar(13) not null,
	User_Email nvarchar(50) primary key,
	User_Password nvarchar(50) not null,
	User_FirstName nvarchar(20) not null,
	User_LastName nvarchar(30) not null,
	User_Title nvarchar(50) not null,
	User_Birthday nvarchar(50) not null,
	User_Active bit not null
)

Bulk insert #csv_temp
FROM 'C:\temp\UserData.csv'
WITH (fieldterminator = ',', rowterminator = '\n');

select top(10) * from #csv_temp

--drop table User_Info

Create table User_Info (
	User_Role nvarchar(13) not null,
	User_Email nvarchar(50) primary key,
	User_Password nvarchar(50) not null,
	User_FirstName nvarchar(20) not null,
	User_LastName nvarchar(30) not null,
	User_Title nvarchar(50) not null,
	User_Birthday date not null,
	User_Active bit not null
)

insert into User_Info
select User_Role, User_Email, User_Password, User_FirstName, User_LastName, User_Title, convert(date, User_Birthday, 110), User_Active 
from #csv_temp

select top(10) * from User_Info

create table Users_Session_Time(
User_Email nvarchar(50) not null,
User_Date date not null,
User_Login_Time time not null,
User_Logout_Time time null,
User_Time_Spent time null,
User_Logout_Reason nvarchar(50) null,
User_Crash bit null
foreign key (User_Email) references User_Info(User_Email)
primary key (User_Date, User_Login_Time)
)