Create table ���������
(���_���������� int Primary key,
��������_���������� nvarchar(50) not null,
����_��������� date not null,
���_������������ nvarchar(50) not null,
����_���_��_��������� int not null
)


Create table �������
(���_������� int Primary key,
��������_������� nvarchar(50) not null,
�����������_������� bit not null,
���� nvarchar(50) not null,
������� nvarchar(50) not null,
���_���������� int not null,
Foreign key (���_����������) references ��������� (���_����������),
���_������� nvarchar not null
)


Create table ������
(�����_������ nvarchar(50) Primary key,
����_���_��_������� int,
���_���������� int not null,
Foreign key (���_����������) references ��������� (���_����������),
�������_������ nvarchar(50) not null
)


Create table �������������
(���_������������� int Primary key,
������� nvarchar(50),
��� nvarchar(50),
�������� nvarchar null,
����������� nvarchar(50),
���� int,
���������_������� int,
���_������� int not null,
Foreign key (���_�������) references ������� (���_�������)
)


Create table ����������
(
���_���������� nvarchar(50) Primary key,
�������� nvarchar(50),
�������� nvarchar(50),
���_��������_��_��������� date
)


Create table ��������
(���������_���� int,
���������_������ int,
���_������������� int not null,
���_���������� nvarchar(50) not null,
Foreign key (���_�������������) references ������������� (���_�������������),
Foreign key (���_����������) references ���������� (���_����������),
primary key(���_�������������,���_����������)
)


Create table �����������
(�����_����������� int primary key,
�������� nvarchar(50),
���_������������ nvarchar(50),
����������_�������_���� int,
�������_�������������_������������ nvarchar(50),
���_������� int not null,
���_������� nvarchar(50) not null,
Foreign key (���_�������) references ������� (���_�������)
)


Create table ����������
(����_������ nvarchar(50) ,
�����_���� int ,
���������� nvarchar(50),
���_������������� int not null,
���_���������� nvarchar(50) not null,
�����_������ nvarchar(50) not null,
�����_����������� int not null,
Foreign key (���_�������������) references ������������� (���_�������������),
Foreign key (���_����������) references ���������� (���_����������),
Foreign key (�����_������) references ������ (�����_������),
Foreign key (�����_�����������) references ����������� (�����_�����������),
Primary key( ����_������, �����_����, ���_�������������, ���_����������,�����_������)
)


Create table �������
(���_�������� int Primary key,
������� nvarchar(50),
��� nvarchar(50),
�������� nvarchar(50),
����_�������� date,
����� nvarchar(50),
������� int,
�����_������ nvarchar(50) not null,
Foreign key (�����_������) references ������ (�����_������)
) 