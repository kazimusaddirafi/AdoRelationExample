create database adorelation;

use adorelation;

create table department(
Id int primary key identity(1,1),
DepartmentName varchar(50) not null
);

create table employee(
Id int primary key identity(1,1),
Name varchar(50) not null,
Pin varchar(50) unique not null ,
DepartmentId int,
Foreign key (DepartmentId) references department(Id)
);

---store procedure

---create department
Go
Create Procedure spCreateDepartment(@DepartmentName varchar(50))
as
begin
	Insert into department(DepartmentName)
	values(@DepartmentName)
end

EXEC spCreateDepartment @DepartmentName = 'ICT';

---get all department
Go
Create Procedure spGetAllDepartment
as
begin
	Select * from department
end

EXEC spGetAllDepartment;


---Create Employees
Go
create procedure spCreateEmployee(@Name varchar(50),@Pin varchar(50),@DepartmentId int)
as
begin
	insert into employee (Name,Pin, DepartmentId)
	values(@Name,@Pin, @DepartmentId)
end

Exec spCreateEmployee @Name="Test", @Pin="1111" ,@DepartmentId=2;

---Get All Employees
Go
create procedure spGetAllEmployees
as
begin
	select e.Id,e.Name,e.Pin, d.DepartmentName 
	from employee e
	inner join department d on e.DepartmentId=d.Id
end

Exec spGetAllEmployees;

---Get Employees By Id
Go
create procedure spGetEmployeeById(@Id int)
as
begin
	select e.Id,e.Name,e.Pin, d.DepartmentName 
	from employee e
	inner join department d on e.DepartmentId=d.Id
	where e.Id=@Id
end

Exec spGetEmployeeById @Id=3;


---Update Employees
Go
create procedure spUpdateEmployee(@Id int,@Name varchar(50),@Pin varchar(50),@DepartmentId int)
as
begin
	update employee set Name=@Name,Pin=@Pin, DepartmentId=@DepartmentId
	where Id=@Id
end

Exec spUpdateEmployee @Id=3, @Name="Abul Hossain", @Pin="9730" ,@DepartmentId=2;

---Delete Employees
Go
create procedure spDeleteEmployee(@Id int)
as
begin
	delete from employee
	where Id=@Id
end

Exec spDeleteEmployee @Id=4;