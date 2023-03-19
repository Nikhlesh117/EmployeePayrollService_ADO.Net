--UC-1: create database payroll-service
create database payroll_service

drop database payroll_service
use payroll_service

--uc-2: create tabble

create table employee(
EmployeeID int identity primary key,
EmployeeName varchar(255),
PhoneNumber varchar(255),
Address varchar(255),
Department varchar(255),
Gender char(1),
Basicpay float,
Deductions float,
TaxablePay float,
Tax float,
NetPay float,
StartDate Date,
City varchar(100),
Country varchar(100)
)

select * from employee
delete from employee
