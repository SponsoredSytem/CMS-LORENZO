ALTER TABLE Company
Add StatusId int null

go
ALTER TABLE Company
ADD CONSTRAINT fk_Company_CompanyStatus
FOREIGN KEY (StatusId)
REFERENCES CompanyStatus(StatusId)