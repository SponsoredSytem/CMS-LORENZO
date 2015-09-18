--alter table to add FK column
ALTER TABLE Company --Comapny is the table, where we FK exist of CompanyStatus atble
Add StatusId int null

go --go ahead after executing above query

--now set FK constraint
ALTER TABLE Company
ADD CONSTRAINT FK_Company_CompanyStatus --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (StatusId) --ForeignKeyColumn
REFERENCES CompanyStatus(StatusId) --PrimaryKeyTable(PrimaryKeyColumn)