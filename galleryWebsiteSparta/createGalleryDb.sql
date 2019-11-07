use master 
go 

drop database if exists GalleryWebsite 
go

create database GalleryWebsite
go

use GalleryWebsite
go


drop table if exists Products
go
drop table if exists Users
go 

create table Products (
	ProductID int not null identity primary key,
	ProductName nvarchar(100) null,
	ProductDescription nvarchar(MAX) null, 
	ProductImage Image null, 
	Price decimal (15, 2) not null,
	ProductAvailability bit not null
);

create table Users (
	UserID int not null identity primary key, 
	FirstName varchar(50) not null,
	LastName varchar(50) not null, 
	UserPassword nvarchar(50) not null,
	Email nvarchar(320) not null
);

insert into Products values ('Mona Lisa', 'The Mona Lisa made by Leonardo da Vinci.', null, 200000000.00, 0);
insert into Products values ('Lona Misa', 'The Mona Lisa made by me.', null, 2.00, 0);
insert into Products values ('The scream', 'The scream made by Edvard Munch.', null, 1500000.00, 0);
insert into Products values ('Image4', 'This is an image.', null, 100.00, 0);
insert into Products values ('Image5', 'This is an image.', null, 100.00, 1);
insert into Products values ('Image6', 'This is an image.', null, 100.00, 0);
insert into Products values ('Image7', 'This is an image.', null, 350.00, 0);
insert into Products values ('Image8', 'This is an image.', null, 200.00, 0);
insert into Products values ('Image9', 'This is an image.', null, 94300.00, 0);
insert into Products values ('Image10', 'This is an image.', null, 100.00, 1);
insert into Products values ('Image11', 'This is an image.', null, 100.00, 1);
insert into Products values ('Image12', 'This is an image.', null, 175.00, 1);
insert into Products values ('Image13', 'This is an image.', null, 100.00, 0);
insert into Products values ('Image14', 'This is an image.', null, 10000.00, 1);
insert into Products values ('Image15', 'This is an image.', null, 100.00, 1);
insert into Products values ('Image16', 'This is an image.', null, 100.00, 0);
insert into Products values ('Image17', 'This is an image.', null, 60.00, 0);
insert into Products values ('Image18', 'This is an image.', null, 100.00, 0);
insert into Products values ('Image19', 'This is an image.', null, 5.00, 1);
insert into Products values ('Image20', 'This is an image.', null, 100.00, 0);

insert into Users values ('Ryan', 'Burdus', 'password', '1996burdus@gmail.com');

select * from Products;
select * from Users;