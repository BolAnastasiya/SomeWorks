Create table Факультет
(код_факультета int Primary key,
название_факультета nvarchar(50) not null,
дата_основания date not null,
род_деятельности nvarchar(50) not null,
макс_кол_во_студентов int not null
)


Create table Кафедра
(код_кафедры int Primary key,
название_кафедры nvarchar(50) not null,
выпускающая_кафедра bit not null,
сайт nvarchar(50) not null,
телефон nvarchar(50) not null,
код_факультета int not null,
Foreign key (код_факультета) references Факультет (код_факультета),
зав_кафедры nvarchar not null
)


Create table Группа
(номер_группы nvarchar(50) Primary key,
макс_кол_во_человек int,
код_факультета int not null,
Foreign key (код_факультета) references Факультет (код_факультета),
куратор_группы nvarchar(50) not null
)


Create table Преподаватель
(код_преподавателя int Primary key,
фамилия nvarchar(50),
имя nvarchar(50),
отчество nvarchar null,
образование nvarchar(50),
стаж int,
контакный_телефон int,
код_кафедры int not null,
Foreign key (код_кафедры) references Кафедра (код_кафедры)
)


Create table Дисциплина
(
код_дисциплины nvarchar(50) Primary key,
название nvarchar(50),
описание nvarchar(50),
год_введения_по_стандарту date
)


Create table Нагрузка
(стоимость_часа int,
почасовая_оплата int,
код_преподавателя int not null,
код_дисциплины nvarchar(50) not null,
Foreign key (код_преподавателя) references Преподаватель (код_преподавателя),
Foreign key (код_дисциплины) references Дисциплина (код_дисциплины),
primary key(код_преподавателя,код_дисциплины)
)


Create table Лаборатория
(номер_лаборатории int primary key,
название nvarchar(50),
род_деятельности nvarchar(50),
количество_рабочих_мест int,
наличие_проекционного_оборудования nvarchar(50),
код_кафедры int not null,
зав_кафедры nvarchar(50) not null,
Foreign key (код_кафедры) references Кафедра (код_кафедры)
)


Create table Расписание
(день_недели nvarchar(50) ,
номер_пары int ,
примечание nvarchar(50),
код_преподавателя int not null,
код_дисциплины nvarchar(50) not null,
номер_группы nvarchar(50) not null,
номер_лаборатории int not null,
Foreign key (код_преподавателя) references Преподаватель (код_преподавателя),
Foreign key (код_дисциплины) references Дисциплина (код_дисциплины),
Foreign key (номер_группы) references Группа (номер_группы),
Foreign key (номер_лаборатории) references Лаборатория (номер_лаборатории),
Primary key( день_недели, номер_пары, код_преподавателя, код_дисциплины,номер_группы)
)


Create table Студент
(код_студента int Primary key,
фамилия nvarchar(50),
имя nvarchar(50),
отчество nvarchar(50),
дата_рождения date,
адрес nvarchar(50),
телефон int,
номер_группы nvarchar(50) not null,
Foreign key (номер_группы) references Группа (номер_группы)
) 