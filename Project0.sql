--create schema Comic

--Running this will drop all of the tables then recreate them and seed them with some default battles.




drop table Comic.OrdersProduct
drop table Comic.Orders
drop table Comic.Customer
drop table Comic.StoreProduct
drop table Comic.Inventory
drop table Comic.ComicStore




--drop table Comic.ComicStore
create table Comic.ComicStore (
	StoreID int primary key identity(1,1),
	Location nvarchar(200) not null unique 
)



--drop table Comic.Inventory
create table Comic.Inventory (
	InventoryId int primary key identity(1,1),
	StoreId int,
	constraint Fk_Inventory_To_ComicStore Foreign Key (StoreID) references Comic.ComicStore(StoreID) on update cascade on delete cascade
)



--drop table Comic.StoreProduct
create table Comic.StoreProduct (
	ID int not null primary key identity(1,1),
	Name nvarchar(100) not null,
	Price money  not null,
	InventorySize int not null,
	InventoryID int, 
	SetID int,
	constraint Price_Is_Positive check (Price > 0),
	constraint Name_Not_Empty check (Name != ''),
	constraint Inventory_Not_Empty check (InventorySize > 0),
	constraint Fk_StoreProduct_To_Inventory Foreign Key (InventoryID) references Comic.Inventory(InventoryID)  on delete cascade on update cascade,
	constraint Fk_StoreSet_To_StoreProduct Foreign Key (SetID) references Comic.StoreProduct(ID)
)




--drop table Comic.Customer
create table Comic.Customer (
	CustomerID int not null primary key identity(1,1),
	Name nvarchar(100) not null,
	Email nvarchar(300) not null,
	StoreID int,
	constraint Fk_Customer_To_Location foreign key (StoreID) references Comic.ComicStore(StoreID) on delete cascade on update cascade,
	constraint Email_Not_Empty check (Email != ''),
)



--drop table Comic.Orders
create table Comic.Orders (
	OrdersID int not null primary key identity(1,1),
	Total money,
	CustomerID int not null,
	OrderTime Datetime2 default(CURRENT_TIMESTAMP),
	constraint Fk_Orders_To_Customer Foreign Key (CustomerID) references Comic.Customer(CustomerID) on delete cascade on update cascade
)





--drop table Comic.OrdersProduct
create table Comic.OrdersProduct (
	ID int not null primary key identity(1,1),
	Name nvarchar(100) not null,
	Price money  not null,
	InventorySize int not null,
	OrdersID int, 
	constraint Fk_OrderProduct_To_OrdersInventory Foreign Key (OrdersID) references Comic.Orders(OrdersID) on delete cascade on update cascade
)



insert into Comic.ComicStore (Location) values ('Storming Comics')
insert into Comic.ComicStore (Location) values ('CloudKill Covers')
insert into Comic.ComicStore (Location) values ('Raining Rivers Bookstore')

insert into Comic.Inventory (StoreId) values 
		(1),
		(2),
		(3)



insert into Comic.StoreProduct(Name,Price,InventorySize,InventoryID) values 
		('Astonishing X-Men',4.99,20,1),
		('Justice League of America',4.99,20,1),
		('New Avengers',4.99,20,1),
		('Batman',4.99,20,1),
		('Amazing Spider-Man',4.99,20,1)





insert into Comic.StoreProduct(Name,Price,InventorySize,InventoryID) values 
		('Astonishing X-Men',4.99,20,2),
		('Justice League of America',4.99,20,2),
		('New Avengers',4.99,20,2),
		('Batman',4.99,20,2),
		('Amazing Spider-Man',4.99,20,2)




insert into Comic.StoreProduct(Name,Price,InventorySize,InventoryID) values 
		('Astonishing X-Men',4.99,20,3),
		('Justice League of America',4.99,20,3),
		('New Avengers',4.99,20,3),
		('Batman',4.99,20,3),
		('Amazing Spider-Man',4.99,20,3)

		



insert into Comic.Customer (Name, Email, StoreID) values
		('Rhonda','rubiorhonda@exists.com',1),
		('Lucy','Lucyisadog@.gmail',2),
		('Matt','Akers@GGmail',3)



insert into Comic.Orders (CustomerID) values
	(1),
	(3),
	(2)



insert into Comic.OrdersProduct(Name,Price,InventorySize,OrdersID) values 
		('Astonishing X-Men',4.99,1,1),
		('Justice League of America',4.99,1,1),
		('New Avengers',4.99,3,2)

update Comic.Orders
set Total = 9.98
where CustomerID = 3


update Comic.Orders
set Total = 14.97
where CustomerID = 1


--comic set
insert into Comic.StoreProduct(Name,Price,InventorySize,InventoryID, SetID) values 
		('Hero Set',4.99,20,3, 1)


update Comic.StoreProduct
set SetID = 2
where Name = 'Astonishing X-Men' and InventoryID = 1



select * from Comic.ComicStore


select * from Comic.Inventory


select * from Comic.StoreProduct


select * from Comic.Customer


select * from Comic.Orders

 
select * from Comic.OrdersProduct


--select SUM(Price * InventorySize)
--from Comic.OrdersProduct
--where OrdersID = 2

--delete from Comic.ComicStore where Location = 'Storming Comics 