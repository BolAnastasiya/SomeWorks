IF DB_ID('�������_����������_�������') IS NOT NULL
begin
	USE master
	drop database �������_����������_�������
end
CREATE DATABASE �������_����������_�������


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
FILEGROWTH= 10%)  -- �������� ���������� 10% 10% 





 -- ���� 2 - �������� ������
  use �������_����������_�������

   CREATE TABLE ���������_�������
(���_��������� int,
�������� nvarchar(100) not null,
�������� nvarchar(100) not null,
���_������������_��������� int not null,
CONSTRAINT PK2 Primary key(���_���������),
CONSTRAINT FK10 FOREIGN KEY (���_������������_���������)  REFERENCES ���������_������� (���_���������)
)

 CREATE TABLE �����
(���_������ int,
�������� nvarchar(100) not null,
�������� nvarchar(100) not null,
��������� money null,
���_��������� int not null,
����������_��_������ int not null,
CONSTRAINT PK1 Primary key(���_������),
CONSTRAINT FK1 FOREIGN KEY (���_���������)  REFERENCES ���������_������� (���_���������)
)



 CREATE TABLE ��������
(���_�������� int,
������� nvarchar(50) not null,
��� nvarchar(50) not null,
�������� nvarchar(50) null,
��������� nvarchar(50) not null,
 ��������_����� nvarchar(100) not null,
 ������� nvarchar(50) not null,
CONSTRAINT PK3 Primary key(���_��������)
)



 CREATE TABLE ����������
(���_���������� int,
������� nvarchar(50) not null,
��� nvarchar(50) not null,
�������� nvarchar(50) null,
����������_������ nvarchar(50) not null,
 ��������_����� nvarchar(100) not null,
 ������� nvarchar(50) not null,
CONSTRAINT PK5 Primary key(���_����������)
)


 CREATE TABLE �������
(�����_������� int,
����_������� date not null,
���_���������� int not null,
���_�������� int not null,
CONSTRAINT PK4 Primary key(�����_�������),
CONSTRAINT FK2 FOREIGN KEY (���_����������)  REFERENCES ���������� (���_����������),
CONSTRAINT FK3 FOREIGN KEY (���_��������)  REFERENCES �������� (���_��������)
)

 CREATE TABLE ����������_�������
(���_������ int,
�����_������� int not null,
���������� int not null,
CONSTRAINT PK6 Primary key(���_������,�����_�������),
CONSTRAINT FK4 FOREIGN KEY (�����_�������)  REFERENCES ������� (�����_�������),
CONSTRAINT FK5 FOREIGN KEY (���_������)  REFERENCES ����� (���_������)
)











