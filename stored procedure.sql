
create table Aspire (
Employee_ID int primary key,
Employee_Name varchar(50) not null, 
Employee_salary decimal(10,2) not null,
Employee_location varchar(50) not null,
DepartmentID int not null,
DateOfJoining date not null,
constraint fk_DepartmentID foreign key (DepartmentID) references departments(DepartmentID)
);

insert into Aspire (Employee_ID,Employee_Name,Employee_salary,Employee_location,DepartmentID,DateOfJoining)
values

(11,'ram',65000,'madurai',102,'2018-03-01'),
(12,'selva',70000,'villupuram',103,'2017-10-04'),
(13,'naresh',35000,'delhi',104,'2015-08-03'),
(14,'kavitha',40000,'pune',105,'2012-11-15'),
(15,'ramya',80000,'bangalore',106,'2017-10-04'),
(16,'kaviya',55000,'hyderabad',107,'2010-04-07');

create table departments (
DepartmentID int primary key, 
DepartmentName varchar(20) not null,
count int not null default 0
);

insert into departments (DepartmentID,DepartmentName,count)
values
(102,'Sales',3),
(103,'Marketing',2),
(104,'IT',2);

select * from Aspire;

select * from departments;

update Aspire set Employee_ID = 17 where Employee_ID = 1;
select * from Aspire where Employee_ID = 17;

update Aspire set DepartmentID = 108 where Employee_ID= 17;
select * from Aspire where DepartmentID = 108;

DELIMITER //
create   procedure update_salary(in Emp_ID int, out updated_salary decimal(10,2))
begin
update Aspire set Employee_salary = Employee_salary * 1.1 -- increase salary
where Employee_ID = Emp_ID;


select salary into updated_salary from Aspire
where Employee_ID = Emp_ID;

end //

DELIMITER ;

call update_salary(17,@updated_salary);
select @updated_salary as 'updated Salary';
drop  procedure update_salary;

DELIMITER //
create   procedure update_salary(in p_EmployeeID int, out updated_salary decimal(10,2))
begin
update Aspire set Employee_salary = Employee_salary * 1.1 -- increase salary
where Employee_ID = p_EmployeeID;


select Employee_salary into updated_salary from Aspire
where Employee_ID = p_EmployeeID;

end //

DELIMITER ;

call update_salary(17,@updated_salary);
select @updated_salary as 'updated Salary';