--Drop Table EmpDetails;
--Drop Table Employee;
--Drop Table Department;

-----------------Table Creation for Department, Employee and Employee Details--------------
Create Table Department(
	DeptID INT NOT NULL,
	Name NVARCHAR(40),
	Location NVARCHAR(40),
	Primary Key(DeptID)
);

Create Table Employee(
	EmployeeId INT NOT NULL,
	FirstName NVARCHAR(40) NOT NULL,
	LastName NVARCHAR(40) NOT NULL,
	SSN INT NOT NULL,
	DeptID INT NOT NULL
	Primary Key(EmployeeID),
	Foreign Key(DeptID) References Department(DeptID)
);

Create Table EmpDetails(
	EmpId INT NOT NULL,
	EmployeeId INT NOT NULL,
	Salary INT NOT NULL,
	Address1 NVARCHAR(40),
	Address2 NVARCHAR(40),
	City NVARCHAR(40),
	eState NVARCHAR(40),
	Country NVARCHAR(40),
	Primary Key(EmpID),
	Foreign Key(EmployeeID) References Employee(EmployeeID)
);
--------------------------End of Table Creation------------------------------------------------------------------
--------------------------Start Insert for tables with 3 each----------------------------------------------------
INSERT INTO Department(DeptID,Name) Values(1,'HR');
INSERT INTO Department(DeptID,Name,Location) Values(10,'Recruiting','Hawaii');
INSERT INTO Department(DeptID,Name,Location) Values(11,'Sales','Canada');
INSERT INTO Employee(EmployeeId, FirstName,LastName,SSN,DeptID) Values(1,'John','Smith',1,1);
INSERT INTO Employee(EmployeeId, FirstName,LastName,SSN,DeptID) Values(10,'Matt','Smith',10,10);
INSERT INTO Employee(EmployeeId, FirstName,LastName,SSN,DeptID) Values(11,'Sam','Smith',11,11);
INSERT INTO EmpDetails(EmpId,EmployeeId,Salary,City,eState,Country) Values(1,1,50000,'Seattle','Washington','US');
INSERT INTO EmpDetails(EmpId,EmployeeId,Salary,City,eState,Country) Values(2,10,50000,'Seattle','Washington','US');
INSERT INTO EmpDetails(EmpId,EmployeeId,Salary,City,eState,Country) Values(3,11,50000,'Seattle','Washington','US');

--------------------------------Adding extra employee and their details along with new department----------------
INSERT INTO Employee(EmployeeId, FirstName,LastName,SSN,DeptID) Values(100,'Tina','Smith',100,1);
INSERT INTO EmpDetails(EmpId,EmployeeId,Salary,City,eState,Country) Values(4,100,50000,'Seattle','Washington','US');
INSERT INTO Department(DeptID,Name) Values(100,'Marketing');
Update Employee Set DeptID = 100 Where EmployeeId = 100; -- changing department of Tina Smith to marketing

-- Returning the Total Salary of all employees in marketing
Select Sum(Salary) As MarketingSum 
From EmpDetails Join Employee On Employee.EmployeeId = EmpDetails.EmployeeId 
Join Department on Employee.DeptID = Department.DeptID 
Where Department.Name = 'Marketing';

-- Returns the total number of employees in each department
Select Name, Count(EmployeeID) As NumEmployee 
From Employee Join Department On Employee.DeptID = Department.DeptID 
Group by Name;

-- Changing the salary of Tina Smith to 90000
Update EmpDetails Set Salary = 90000 
From Employee Join EmpDetails On Employee.EmployeeId = EmpDetails.EmployeeId 
Where Employee.FirstName = 'Tina' AND Employee.LastName = 'Smith';

Select * From Department;
Select * From Employee;
Select * From EmpDetails;
