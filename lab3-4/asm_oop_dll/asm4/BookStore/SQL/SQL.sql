create database BookStore
go
use BookStore
go
create table Books(
	BookID int,
	BookName varchar(50),
	BookPrice float
)
go
create table Employee(
	EmpID char(10),
	EmpPassword  char(15),
	EmpRole bit
)
