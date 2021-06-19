create database PhamThanhTamDB
go
use PhamThanhTamDB
go
create table  UserAccount (
  IDUser int IDENTITY(1,1) PRIMARY KEY,
  UserName nvarchar(250) not null,
  Password varchar(250)not null ,
  Status bit
)
insert into UserAccount(UserName,Password,Status) values
	('admin','21232f297a57a5a743894a0e4a801fc3',1),
	('tampham1','f3cb247b641353778ad794cb236f3b58',0),
	('phamabc','f3cb247b641353778ad794cb236f3b58',1),
	('abc23','f3cb247b641353778ad794cb236f3b58',1),
	('vv123','f3cb247b641353778ad794cb236f3b58',0)
create table  Category 
(
	IDCategory int IDENTITY(1,1) PRIMARY KEY,
	NameCategory nvarchar(250) not null,
	DescriptionCategory nvarchar(250) ,

)
insert into Category(NameCategory,DescriptionCategory) values
	(N'Quần Áo' ,N'Quần Áo Thể Thao'),
	(N'Giày',N'Giày Thể Thao'),
	(N'Đồ Bảo Hộ' ,N'Đồ Bảo Hộ Tránh Chấn Thương'),
	(N'Dụng Cụ Khác',N'Dụng Cụ .......')
	
create table  Product 
(
	IDProduct int IDENTITY(1,1) PRIMARY KEY,
	NameProduct nvarchar(250),
	UnitCost int not null,
	Quantity int not null,
	Image nvarchar(250) ,
	DescriptionProduct nvarchar(250),
	Status bit,
	CategoryNO int constraint FK_CategoryNO foreign key references Category(IDCategory)
		on delete cascade
		on update cascade
)
insert into Product(NameProduct,UnitCost,Quantity,Image,DescriptionProduct,Status,CategoryNO) values
	(N'Bộ Quần Áo Thể Thao Con Thỏ' ,175000,100,'ao1.jpg',N'Phong Cách ,Thoáng Mát , Size :S,M,L',1,1),
	(N'Bộ Quần Áo Thể Thao Doremon' ,200000,150,'ao2.jpg',N'Phong Cách ,Thoáng Mát , Size :S,M,L',1,1),
	(N'Bộ Quần Áo Thể Thao Juventus' ,250000,130,'ao3.jpg',N'Phong Cách ,Thoáng Mát , Size :S,M,L',1,1),
	(N'Bộ Quần Áo Thể Thao Liverpool' ,240000,500,'ao4.jpg',N'Phong Cách ,Thoáng Mát , Size :S,M,L',1,1),
	(N'Giày Thế Thao Adidas V1 ',2000000,70,'giay1.jpg',N'Phong Cách ,Thoải Mái, Size :38, 39, 40, 41, 42, 43',1,2),
	(N'Giày Thế Thao Adidas V2 ',1900000,150,'giay2.jpg',N'Phong Cách ,Thoải Mái, Size :38, 39, 40, 41, 42, 43',1,2),
	(N'Giày Thế Thao CR7 Nike V1 ',1500000,40,'giay3.jpg',N'Phong Cách ,Thoải Mái, Size :38, 39, 40, 41, 42, 43',1,2),
	(N'Giày Thế Thao CR7 Nike  V2',1700000,50,'giay4.jpg',N'Phong Cách ,Thoải Mái, Size :38, 39, 40, 41, 42, 43',1,2)
	

