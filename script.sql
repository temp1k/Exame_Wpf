--create database wpfCrud
--go


use wpfCrud
go

create table Genders (
	ID int not null identity(1,1) primary key,
	[name] nvarchar(20) not null unique,
)
go

create table Members (
	ID int not null identity(1,1) primary key,
	name nvarchar(50) not null unique,
	gender int not null,
	FOREIGN KEY (gender) references Genders(ID)
)
go

alter table Members
ADD CONSTRAINT [MinLengthConstraint] CHECK (DATALENGTH([name]) > 2)
go

insert into Members(name, gender)
values ('ан', 1)
go

insert into Genders(name)
values ('Неизвестно')
go

select * from Members
go