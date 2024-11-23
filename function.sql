use employee_db;
DELIMITER //
CREATE procedure get_employees_by_location(in location varchar(20))

begin
 select * from Aspire
 where Employee_location = location;
 end //
 
 DELIMITER ;
 
call get_employees_by_location('madurai');