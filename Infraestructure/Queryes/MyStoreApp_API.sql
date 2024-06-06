Create database MyStoreApp;
use mystoreapp;
create table ProductType(
Id nvarchar(40) primary key,
Code nvarchar(100) not null,
Name nvarchar(50) not null,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table Prices(
Id	nvarchar(40) primary Key,
Price decimal not null,
DiscountPrice decimal,
PromotionPrice decimal,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);
create table Products (
Id nvarchar(40) primary key,
Code nvarchar (100)not null,
Description nvarchar(500),
UrlImage nvarchar(200),
Name Nvarchar (50) not null,
Units nvarchar(100),
ExpirationDate date,
State bool default true,
Price nvarchar(40),
constraint foreign key (price) references Prices(Id),
Type nvarchar(40),
constraint foreign key (Type) references  ProductType(id),
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);
create table Employees(
Id nvarchar(40) primary Key,
Name nvarchar (40) not null,
LastName nvarchar(40) not null,
Address nvarchar(200),
PhoneNumber nvarchar(50),
Email nvarchar(100),
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table Users(
Id nvarchar(40) primary Key,
Name nvarchar(40) not null,
EmployeeId nvarchar(40),
constraint foreign key(EmployeeId) references Employees(Id),
Password binary,
Locked datetime,
ChangePassword bool default false,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table Roles(
Id nvarchar(40) primary Key,
Name nvarchar(40) not null,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table ScreensUI(
Id nvarchar (40) primary key,
Name nvarchar(40) not null,
Route nvarchar(100) not null,
Icon nvarchar(100) not null,
State bool default true
);

create table RolScreenUI(
ScreenUIID nvarchar(40) ,
constraint foreign key(ScreenUIID) references ScreensUI(Id),
RolID nvarchar(40) ,
constraint foreign key(RolID) references Roles(Id),
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp,
constraint primary Key (ScreenUIID,RolId)
);

create table UserRol(
UserID nvarchar(40) ,
constraint foreign key(UserID) references Users(Id),
RolID nvarchar(40) ,
constraint foreign key (RolID) references Roles(Id),
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp,
constraint primary Key(UserID,RolID)
);

create table Customers(
Id nvarchar(40) primary key,
Name nvarchar(50) not null,
LastName nvarchar(50) not null,
Identification nvarchar(20),
Address Nvarchar(100) not null,
DateBirth date not null,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table Invoices(
Id nvarchar(40) primary Key,
InvoiceID Int not null,
EmployeeId nvarchar(40),
constraint foreign key (EmployeeId) references Employees(Id),
CustomerId nvarchar(40) ,
constraint foreign key (CustomerId) references Customers(Id),
PreInvoicing bool default true,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
);

create table InvoiceDetail(
Id nvarchar(40) primary key,
InvoiceId nvarchar(40) ,
constraint foreign key (InvoiceId) references Invoices(Id),
ProductId nvarchar(40),
constraint foreign key (ProductId)  references Products(Id),
Units int not null,
Price decimal not null,
IVA decimal,
State bool default true,
CreatedBy nvarchar(40) not null,
CreatedDate datetime default current_timestamp,
UpdatedOn nvarchar (40),
UpdatedDate datetime on update current_timestamp
)