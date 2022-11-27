create table users (
UserID int,
UserName varchar(200),
ClientID int);
create table orders (
OrderID int,
Total decimal(12,2),
UserID int);