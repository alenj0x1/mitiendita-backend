create database mitiendita_db
go

use mitiendita_db
go

create table Store (
  storeId int primary key identity(1, 1),
  name varchar(100) not null,
  description varchar(100) not null,
  imageUrl varchar(100),
  cash money default 0,
  createdAt datetime default getdate()
)
go

create table Manager (
  managerId int primary key identity(1, 1),
  mail varchar(100) not null,
  password varchar(255) not null,
  password_hint varchar(100) not null,
  createdAt datetime default getdate(),
  storeId int references Store(storeId) not null
)
go

create table Cash (
  cashId int primary key identity(1, 1),
  createdAt datetime default getdate(),
  storeId int references Store(storeId) not null
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

create table [User] (
  userId int primary key identity(1, 1),
  mail varchar(100) not null,
  paswword varchar(255) not null,
  password_Hint varchar(100) not null,
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

create table Cashier (
  cashierId int primary key identity(1, 1),
  mail varchar(100) not null,
  password varchar(255) not null,
  password_hint varchar(100) not null,
  cash int references Cash(cashId) not null,
  createdAt datetime default getdate(),
  storeId int references Store(storeId) not null
)
go
