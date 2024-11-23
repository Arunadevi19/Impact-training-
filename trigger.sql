use employee_db;
 DELIMITER //
 
 create trigger update_depart_count after insert on Aspire for each row
 
 begin
 update departments set Count = Count + 1
 where DepartmentID = NEW.DepartmentID;
 
 end //
 
 DELIMITER ;
 
 insert into Aspire (Employee_ID,Employee_Name,Employee_salary,Employee_location,DepartmentID,DateOfJoining)
 values (18,'gopi',77000,'chennai',110,'2020-07-07');

select * from departments;

 