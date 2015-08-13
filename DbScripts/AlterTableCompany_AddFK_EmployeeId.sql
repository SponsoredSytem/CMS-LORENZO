ALTER TABLE Company
Add EmployeeId nvarchar(128) null

go
ALTER TABLE Company
ADD CONSTRAINT fk_Company_AspNetUsers
FOREIGN KEY (EmployeeId)
REFERENCES AspNetUsers(Id)