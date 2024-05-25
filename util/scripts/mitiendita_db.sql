create database mitiendita_db
go

use mitiendita_db
go

create table AppRoles (
  roleId int primary key identity(1, 1),
  name varchar(10) not null,
  createdAt datetime default getdate()
)
go

insert into AppRoles (name)
values ('superadmin'), ('admin'), ('manager'), ('cashier'), ('user')
go

create table Store (
  storeId int primary key identity(1, 1),
  name varchar(100) not null,
  description varchar(100) not null,
  imageUrl varchar(100),
  balance money default 0,
  moneyType varchar(10) not null,
  iva int not null,
  createdAt datetime default getdate()
)
go

create table Cash (
  cashId int primary key identity(1, 1),
  createdAt datetime default getdate(),
  storeId int references Store(storeId) not null
)
go

create table [User] (
  userId int primary key identity(1, 1),
  mail varchar(100) not null,
  password varchar(255) not null,
  passwordHint varchar(100) not null,
  userRole int default 5 references AppRoles(roleId),
  createdAt datetime default getdate(),
  cashId int references Cash(cashId),
  storeId int references Store(storeId),
)
go

create table Product (
  productId int primary key identity(1, 1),
  name varchar(50) not null,
  brand varchar(50) not null,
  price money not null,
  stock int default 0,
  createdAt datetime default getdate(),
  storeId int references Store(storeId) not null
)
go

create table Sell (
  sellId int primary key identity(1, 1),
  amount money not null,
  createdAt datetime default getdate(),
  userId int references [User](userId),
  storeId int references Store(storeId) not null
)
go

create table SellProduct (
  sellId int primary key references Sell(sellId),
  productId int references Product(productId),
  amount int default 1
)
go
