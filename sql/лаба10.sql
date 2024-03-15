--Дано целое положительное число. Необходимо удалить из числа все цифры, слева от 
--которых находится большая цифра. Результат вывести в область системных 
--сообщений. 


Declare @x int
Declare @i int
Declare @j int
Declare @a int
set @a = 0
Set @x = 400454
While @x>0
begin
Set @i = @x %10
Set @j= @x %100 /10
if @j<=@i
begin
set @a *= 10
Set @a += @i
end
Set @x = @x/10 
end
--print  @a
Declare @x1 int
Declare @i1 int
set @x1 = 0
set @i1 = 0
while @a>0
begin
set @i1 = @a %10
set @a /= 10
set @x1 *=10
set @x1 += @i1
end
print @x1






Declare @x int
Declare @i int
Declare @j int
Declare @s varchar(100)
Set @x = 400454
Set @s = cast(@x as varchar(100))
set @i = 0
while @i < 10
begin 
set @j = 0
while @j<@i
begin
Set @s = REPLACE(@s, cast(@i as varchar(2))+cast(@j as varchar(2)), cast(@i as varchar(2))+'*')
Set @j += 1
end
Set @i += 1
end 
SET @s = REPLACE(@s, '*', '')
print @s





--Declare @x int
--Declare @t table (a bigint)
--Declare @i int
--Declare @j int
--Set @x = 400454
--While @x>0 
--begin
--insert into @t values (@x)
--set @i = @x %10
--set @j= @x %100 /10
--if @j<=@i
--begin
--update @t set a*=10
--update @t set a+=@i
--end
--set @x = @x/10 
--End
--Select a 
--from @t






--Declare @t table (a int)
--Declare @x int
--Declare @i int
--Declare @j int
--Declare @a int
--set @a = 0
--Set @x = 400454
--While @x>0
--begin
--Set @i = @x %10
--Set @j= @x %100 /10
--if @j<=@i
--begin
--set @a *= 10
--Set @a += @i
--end
--Set @x = @x/10 
--end
----print  @a
----Declare @x1 int
----Declare @i1 int
----set @x1 = 0
----set @i1 = 0
----while @a>0
----begin
----set @i1 = @a %10
----set @a /= 10
----set @x1 *=10
----set @x1 += @i1
----end
--insert into @t values (@a)
--Select * from @t




--Declare @x int
--Declare @i int 
--Declare @j int 
--Declare @t table (s varchar(100))
--Set @x = 400454 
--insert into @t values (cast(@x as varchar(100))) 
--set @i = 0 
--while @i < 10 
--begin  
--set @j = 0 
--while @j<@i 
--begin 
--update @t set s = REPLACE(s, cast(@i as varchar(2))+cast(@j as varchar(2)), cast(@i as varchar(2))+'*') 
--Set @j += 1 
--end 
--Set @i += 1 
--end  
--select s = REPLACE(s, '*', '') 
--from @t

--Declare @x int
--Declare @t table (a int)
--Set @x = 400454 
--insert into @t values (@x) 
--select t3.a from @t t1, @t t2, @t t3 where  (t3.a =  
--(select t2.a, t1.a  from @t t1, @t t2 where  t1.a>=t2.a and t1.a= (select t2.a, t1.a  from @t t1, @t t2
--where  t1.a = t1.a%10 and t2.a = (select t2.a from @t t2 where exists t2.a%100/10 ))))



--declare @x int
--declare @t table (i int)
--set @x = 400454
--insert into @t values (@x)
--select REPLICATE (case WHEN CHARINDEX('9',i)>0 THEN '9'
--					   WHEN CHARINDEX('8',i)>0 THEN '8'
--					   WHEN CHARINDEX('7',i)>0 THEN '7'
--					   WHEN CHARINDEX('6',i)>0 THEN '6'
--					   WHEN CHARINDEX('5',i)>0 THEN '5'
--					   WHEN CHARINDEX('4',i)>0 THEN '4'
--					   WHEN CHARINDEX('3',i)>0 THEN '3'
--					   WHEN CHARINDEX('2',i)>0 THEN '2'
--					   WHEN CHARINDEX('1',i)>0 THEN '1'
--					   ELSE '0' END, LEN(i)) 
--from @t





Declare @x int , @a nvarchar(50)
Declare @i int 
Declare @t table(ind int, digit int) 
set @x = 9897600
set @i=1 
while @x > 0 
begin  
insert into @t(digit,ind) 
values(@x%10,@x/10%10) 
set @x=@x/10 
set @i+=1 
end 
select @a = COALESCE(@a + '','')  + cast(digit as varchar(50)) from @t where ind-digit<=0
select REVERSE(@a)






--set @i=1 
--declare @ind int 
--set @ind = (select max(ind) from @t) 
--while @i<=@ind 
--begin 
--delete from @t where ind = 
--(select a1.ind from
--(select t1.ind, t1.digit from @t t1 where t1.ind = @i) as a1,
--(select ind, digit from @t where ind = @i+1) as a2
--where a1.digit < a2.digit)
--set @i+=1
----end
--select @a = COALESCE(@a + '','') + cast(digit as varchar(50)) from @t
--select reverse(@a)






--DECLARE @Names VARCHAR(8000) 
--SELECT @Names = COALESCE(@Names,'') + cast(kr as varchar(50))
--FROM (SELECT digit as kr
--FROM @t) t5
--print cast(reverse(@Names) as int)


--Дана произвольная строка. Посчитать количество согласных букв в каждом слове. 
--Результат вывести в области отображения данных.


Declare @s nvarchar(100)
Declare @ss nvarchar(100)
Declare @i int
set @i = 1
Set @s = 'я люблю базы данных'
set @ss =  REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@s,
'а', ''), 'я', ''), 'о', ''), 'ё', ''), 'у', ''),
'ю', ''), 'ы', ''), 'и', ''), 'э', ''), 'е', '')
select @ss = REPLACE(@ss, ' ','')
While @i<len(@ss)
begin
select @ss = SUBSTRING(@ss,1,100)
Set @i = @i+1 
end
select @i





Declare @s varchar(256) = 'я люблю базы данных'
SELECT sum(len(
trim(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
lower(value),
'а', ''), 'я', ''), 'о', ''), 'ё', ''), 'у', ''),
'ю', ''), 'ы', ''), 'и', ''), 'э', ''), 'е', '')
))
)
FROM string_split (@s,' ')








--WHILE @s != '' 
--BEGIN
--SET @b = charindex(' ', @s)
--IF @b = 0 BEGIN INSERT INTO @t VALUES (@s) 
--SET @s = ''  continue
--END
--INSERT INTO @t VALUES (SUBSTRING(@s, 1, @b-1))
--SET @s = rtrim(ltrim(SUBSTRING(@s, @b+1, 256)))
--END
--select * from @t




