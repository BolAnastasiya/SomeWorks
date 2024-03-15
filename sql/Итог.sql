IF DB_ID('Система_реализации_товаров') IS NOT NULL
begin
	USE master
	drop database Система_реализации_товаров
end
CREATE DATABASE Система_реализации_товаров


ON PRIMARY
( 
  NAME = SP_F1,
  FILENAME = 'C:\SqlDataBase\testDataBase1_1.mdf',
  SIZE = 700MB,
  MAXSIZE = 10536MB,
  FILEGROWTH = 200MB 
 ),
 (NAME = SP_F2,
  FILENAME = 'C:\SqlDataBase\testDataBase1_2.mdf',
   SIZE = 700MB,
  MAXSIZE = 10536MB,
  FILEGROWTH = 200MB 
 ),

 FILEGROUP FileGR
(Name = ExeCutionJobsFGFile1,
FILENAME = 'C:\SqlDataBase\testDataBase1_1.ndf',
SIZE = 1MB,
MAXSIZE=10MB,
FILEGROWTH =1MB),
(Name = ExeCutionJobsFG1File2,
FILENAME = 'C:\SqlDataBase\testDataBase1_2.ndf',
SIZE = 1MB,
MAXSIZE=10MB,
FILEGROWTH =1MB)
 
 LOG ON
(Name = SP_J2,
FILENAME = 'C:\SqlDataBase\log1.ldf',
SIZE = 50MB,
MAXSIZE = 500MB,
FILEGROWTH= 10%)  -- написать приращение 10% 10% 





 -- Этап 2 - создание таблиц
  use Система_реализации_товаров

   CREATE TABLE Категории_товаров
(код_категории int,
название nvarchar(100) not null,
описание nvarchar(100) not null,
код_родительской_категории int not null,
CONSTRAINT PK2 Primary key(код_категории),
CONSTRAINT FK10 FOREIGN KEY (код_родительской_категории)  REFERENCES Категории_товаров (код_категории)
)

 CREATE TABLE Товар
(код_товара int,
название nvarchar(100) not null,
описание nvarchar(100) not null,
стоимость money null,
код_категории int not null,
количество_на_складе int not null,
CONSTRAINT PK1 Primary key(код_товара),
CONSTRAINT FK1 FOREIGN KEY (код_категории)  REFERENCES Категории_товаров (код_категории)
)



 CREATE TABLE Продавцы
(код_продавца int,
фамилия nvarchar(50) not null,
имя nvarchar(50) not null,
отчество nvarchar(50) null,
должность nvarchar(50) not null,
 домашний_адрес nvarchar(100) not null,
 телефон nvarchar(50) not null,
CONSTRAINT PK3 Primary key(код_продавца)
)



 CREATE TABLE Покупатели
(код_покупателя int,
фамилия nvarchar(50) not null,
имя nvarchar(50) not null,
отчество nvarchar(50) null,
паспортные_данные nvarchar(50) not null,
 домашний_адрес nvarchar(100) not null,
 телефон nvarchar(50) not null,
CONSTRAINT PK5 Primary key(код_покупателя)
)


 CREATE TABLE Покупки
(номер_покупки int,
дата_покупки date not null,
код_покупателя int not null,
код_продавца int not null,
CONSTRAINT PK4 Primary key(номер_покупки),
CONSTRAINT FK2 FOREIGN KEY (код_покупателя)  REFERENCES Покупатели (код_покупателя),
CONSTRAINT FK3 FOREIGN KEY (код_продавца)  REFERENCES Продавцы (код_продавца)
)

 CREATE TABLE Содержимое_покупок
(код_товара int,
номер_покупки int not null,
количество int not null,
CONSTRAINT PK6 Primary key(код_товара,номер_покупки),
CONSTRAINT FK4 FOREIGN KEY (номер_покупки)  REFERENCES Покупки (номер_покупки),
CONSTRAINT FK5 FOREIGN KEY (код_товара)  REFERENCES Товар (код_товара)
)











