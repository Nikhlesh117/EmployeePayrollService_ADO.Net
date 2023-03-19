create procedure SpAddEmployeeDetails
(
@EmployeeName varchar(255),
@PhoneNumber varchar(255),
@Address varchar(255),
@Department varchar(255),
@Gender char(1),
@Basicpay float,
@Deductions float,
@TaxablePay float,
@Tax float,
@NetPay float,
@StartDate Date,
@City varchar(255),
@Country varchar(255)
)
as
begin

insert into employee values(@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@Basicpay,@Deductions
,@TaxablePay,@Tax,@NetPay,@StartDate,@City,@Country)

end
go

create   procedure spUpdateSalary
(
@EmployeeName varchar(255),
@Salary int,
@PhoneNumber varchar(255),
@Address varchar(255),
@Department varchar(255),
@Gender char(1),
@City varchar(100),
@Country varchar(100),
@BasicPay float,
@Deductions float,
@TaxablePay float,
@Tax float,
@NetPay float,
@StartDate Date

)
as
begin
update SALARY
set EMPSAL=@salary
where name=@EmployeeName;
end
go