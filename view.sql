use employee_db;
create view seniormost_employee as 
select * from Employees order by dateofjoining asc limit 1;

select * from seniormost_employee;