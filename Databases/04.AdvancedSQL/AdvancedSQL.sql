--Remove '----' after each task and execute with F5

--TASK 1 Write a SQL query to find the names and salaries of the employees that take 
--the minimal salary in the company. Use a nested SELECT statement.

----SELECT FirstName, LastName, Salary
----FROM Employees e
----WHERE Salary = 
----	(SELECT MIN(Salary) FROM Employees)

--TASK 2 Write a SQL query to find the names and salaries of the employees that have 
--a salary that is up to 10% higher than the minimal salary for the company.

----SELECT FirstName, LastName, Salary
----FROM Employees e
----WHERE Salary <
----	(SELECT MIN(Salary) FROM Employees) * 1.1

--TASK 3 Write a SQL query to find the full name, salary and department of the employees 
--that take the minimal salary in their department. Use a nested SELECT statement.

----SELECT EmployeeID, FirstName, LastName, Salary, DepartmentID
----FROM Employees e
----WHERE Salary = 
----	(SELECT MIN(Salary)
----	FROM Employees
----	WHERE DepartmentID = e.DepartmentID)
----ORDER BY DepartmentID

--TASK 4 Write a SQL query to find the average salary in the department #1.

----SELECT AVG(Salary) [Avg salary dep #1]
----FROM Employees
----WHERE DepartmentID = 1

--TASK 5 Write a SQL query to find the average salary in the "Sales" department.

----SELECT AVG(Salary) [Avg salary dep 'Sales']
----FROM Employees e
----WHERE e.DepartmentID IN
----	(SELECT DepartmentID
----	FROM Departments
----	WHERE DepartmentID = 'Sales')

--TASK 6 Write a SQL query to find the number of employees in the "Sales" department.

----SELECT COUNT(*) [Employees in 'Sales' dep.]
----FROM Employees e
----WHERE e.DepartmentID IN
----	(SELECT DepartmentID
----	FROM Departments
----	WHERE Name = 'Sales')

--TASK 7 Write a SQL query to find the number of all employees that have manager.

----SELECT COUNT(*) [Empl with Mngr]
----FROM Employees
----WHERE ManagerID IS NOT NULL

--TASK 8 Write a SQL query to find the number of all employees that have no manager.

----SELECT COUNT(*)
----FROM Employees
----WHERE ManagerID IS NULL

--TASK 9 Write a SQL query to find all departments and the average salary for each of them.
----SELECT DepartmentID, AVG(Salary) AverageSalary
----FROM Employees
----GROUP BY DepartmentID

--!!!TASK 10 Write a SQL query to find the count of all employees in each department and for each town.
----SELECT d.Name, t.Name, COUNT(*)
----FROM Employees e 
----JOIN Departments d ON e.DepartmentId = d.DepartmentId
----JOIN Addresses a ON e.AddressId = a.AddressId
----JOIN Towns t ON t.TownId = a.AddressId
----GROUP BY d.DepartmentId, d.Name, t.Name;

--TASK 11 Write a SQL query to find all managers that have exactly 5 employees. 
--Display their first name and last name.

----SELECT COUNT(m.ManagerID) [Empl count], m.FirstName, m.LastName
----FROM Employees m
----	INNER JOIN Employees e
----		ON m.EmployeeID = e.ManagerID
----GROUP BY m.LastName, m.FirstName
----HAVING COUNT(m.ManagerID) = 5

--TASK 12 Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".

----SELECT e.FirstName, e.LastName, COALESCE(m.FirstName, '(no manager)') + ' ' + COALESCE(m.LastName, '') as Manager
----FROM Employees e
----	LEFT OUTER JOIN Employees m
----		ON e.ManagerID = m.EmployeeID

--TASK 13 Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
--Use the built-in LEN(str) function.

----SELECT e.FirstName, e.LastName
----FROM Employees e
----WHERE LEN(e.LastName) = 5

--TASK 14 Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.

----SELECT GETDATE()

--TASK 15 Write a SQL statement to create a table Users. Users should have username, password, 
--full name and last login time. Choose appropriate data types for the table fields. 
--Define a primary key column with a primary key constraint. Define the primary key column 
--as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
--Define a check constraint to ensure the password is at least 5 characters long.

----CREATE TABLE Users (
----	UserID INT IDENTITY,
----		CONSTRAINT PK_Users PRIMARY KEY(UserID),
----	UserName NVARCHAR(100) NOT NULL,
----		CONSTRAINT UK_UserName UNIQUE (UserName),
----	[Password] NVARCHAR(100) NOT NULL CHECK (LEN([Password]) >= 5),
----	FullName NVARCHAR(200) NOT NULL,
----	LastLoginTime SMALLDATETIME NOT NULL,
----)

----GO

--TASK 16 Write a SQL statement to create a view that displays the users from the 
--Users table that have been in the system today. Test if the view works correctly.

----CREATE VIEW [Users logged today] AS
----SELECT UserName, LastLoginTime
----FROM Users
----WHERE 
----	DATEPART(YEAR, LastLoginTime) = DATEPART(YEAR, GETDATE()) AND
----	DATEPART(MONTH, LastLoginTime) = DATEPART(MONTH, GETDATE()) AND
----	DATEPART(DAY, LastLoginTime) = DATEPART(DAY, GETDATE())
----GO

--TASK 17 Write a SQL statement to create a table Groups. Groups should have unique name 
--(use unique constraint). Define primary key and identity column.

----CREATE TABLE Groups (
----	GroupID INT IDENTITY PRIMARY KEY,
----	NAME NVARCHAR(100) NOT NULL UNIQUE
----)

--TASK 18 Write a SQL statement to add a column GroupID to the table Users. 
--Fill some data in this new column and as well in the Groups table. 
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

----ALTER TABLE Users 
----ADD GroupID INT

----ALTER TABLE Users
----ADD CONSTRAINT FK_GroupID
----  FOREIGN KEY (GroupID)
----  REFERENCES Groups(GroupID)

--TASK 19 Write SQL statements to insert several records in the Users and Groups tables.
----INSERT INTO Users
----VALUES ('Pesho', 'Pesho1', 'Pesho2', '2012-01-01 12:12:12', '2')
----INSERT INTO Users
----VALUES ('Gosho', 'Gosho1', 'Gosho2', '2013-05-01 12:12:12', '2')

----INSERT INTO Groups
----VALUES ('Dogs')
----INSERT INTO Groups
----VALUES ('Insects')

--TASK 20 Write SQL statements to update some of the records in the Users and Groups tables.

----UPDATE Users
----SET UserName='Gergi', Password='geshkata'
----WHERE UserName='Gosho';

----UPDATE Groups
----SET NAME='Hamsters'
----WHERE NAME='kotki'

----UPDATE Groups
----SET Name='Cats'
----WHERE Name='kotnk'

----UPDATE Users
----SET GroupID = '3'
----WHERE UserName = 'Gergi'

--TASK 21 Write SQL statements to delete some of the records from the Users and Groups tables.

----DELETE FROM Users
----WHERE GroupID = '2'

----DELETE FROM Groups
----WHERE Name = 'motki'

--My correction to table Users

----ALTER TABLE Users 
----ALTER COLUMN LastLoginTime SMALLDATETIME NULL

--TASK 22 Write SQL statements to insert in the Users table the names of all employees from 
--the Employees table. Combine the first and last names as a full name. For username use 
--the first letter of the first name + the last name (in lowercase). Use the same for the password, 
--and NULL for last login time.

----INSERT INTO Users (UserName, [Password], Fullname, LastLoginTime, GroupID)
----SELECT 
----	LEFT(FirstName, 5) + LOWER(LastName), --has to be unique
----	LEFT(FirstName, 1) + LOWER(LastName) + '_pass', 
----	FirstName + ' ' + LastName, 
----	NULL, 
----	NULL
----FROM Employees

--TASK 23 Write a SQL statement that changes the password to NULL for all users that 
--have not been in the system since 10.03.2010.

----ALTER TABLE Users
----ALTER CoLUMN Password NVARCHAR(100) NULL --changes the password from 'not-null' to 'null'

----UPDATE Users
----SET Password = NULL
----WHERE 
----	LastLoginTime < '2010-03-10 00:00:00'

--TASK 24 Write a SQL statement that deletes all users without passwords (NULL password).

----DELETE FROM Users
----WHERE Password IS NULL

--TASK 25 Write a SQL query to display the average employee salary by department and job title.

----SELECT d.Name DepartmentName, e.JobTitle, AVG(e.Salary) AvgSalary
----FROM Employees e
----	INNER JOIN Departments d
----		ON e.DepartmentID = d.DepartmentID
----GROUP BY d.Name, e.JobTitle

--TASK 26 Write a SQL query to display the minimal employee salary by department and job title 
--along with the name of some of the employees that take it.

----SELECT d.Name DepartmenName, e.JobTitle, e.Salary MinSalary, e.FirstName, e.LastName
----FROM Employees e
----	INNER JOIN Departments d
----		ON e.DepartmentID = d.DepartmentID
----WHERE e.Salary = 
----	(SELECT MIN(Salary) 
----	FROM Employees emp
----	WHERE emp.DepartmentId = e.DepartmentId);

--TASK 27 Write a SQL query to display the town where maximal number of employees work.

----SELECT TOP 1 t.Name, COUNT(e.EmployeeID) EmployeeCount
----FROM Employees e
----	INNER JOIN Addresses a
----		ON e.AddressID = a.AddressID
----	INNER JOIN Towns t
----		ON a.TownID = t.TownID
----GROUP BY t.Name
----ORDER by EmployeeCount DESC

--TASK 28 Write a SQL query to display the number of managers from each town.

----SELECT t.Name as Town, COUNT(e.ManagerID) AS ManagersCount
----FROM Employees e
----	JOIN Addresses a 
----		ON e.AddressID = a.AddressID
----	JOIN Towns t 
----		ON t.TownID = a.TownID
----WHERE e.EmployeeID IN
----	(SELECT DISTINCT ManagerID FROM Employees)
----GROUP BY t.Name

--!!!TASK 29 Write a SQL to create table WorkHours to store work reports for 
--each employee (employee id, date, task, hours, comments). Don't forget to 
--define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command
--(insert / update / delete).

----CREATE TABLE Tasks
----    (
----        TaskID INT IDENTITY(1,1) PRIMARY KEY,
----        NAME nvarchar(50) NOT NULL
----    )
 
----CREATE TABLE WorkHours 
----    (
----        WorkHoursID INT IDENTITY(1,1) PRIMARY KEY,
----        EmployeeID INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
----        [DATE] datetime NOT NULL,
----        TaskID INT FOREIGN KEY(TaskID) REFERENCES Tasks(TaskID) NOT NULL,
----        [Hours] INT NULL,
----        Comments nvarchar(250) NULL,
----    )
 
----INSERT INTO WorkHours
----    VALUES(5, '2013-07-12', 4, NULL, NULL)
 
----CREATE TABLE WorkHoursLog
----    (
----        LogID INT IDENTITY(1,1) PRIMARY KEY,
----        ExecutedCommand nvarchar(20) NULL,
----        WorkHoursID INT NULL,
----        OldEmployeeID INT FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
----        [OldDate] datetime NULL,
----        OldTaskID INT FOREIGN KEY(OldTaskID) REFERENCES Tasks(TaskID) NULL,
----        [OldHours] INT NULL,
----        OldComments nvarchar(250) NULL,
----        NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
----        [NewDate] datetime NULL,
----        NewTaskID INT FOREIGN KEY(NewTaskID) REFERENCES Tasks(TaskID) NULL,
----        [NewHours] INT NULL,
----        NewComments nvarchar(250) NULL
----    )
 
----ALTER TRIGGER TR_WorkHoursDelete
----ON WorkHours
----FOR DELETE
----AS
----    INSERT INTO WorkHoursLog
----    SELECT 'DELETE', *, NULL, NULL, NULL, NULL, NULL
----        FROM deleted
 
----GO
 
----ALTER TRIGGER TR_WorkHoursInsert
----ON WorkHours
----FOR INSERT
----AS
----    INSERT INTO WorkHoursLog
----    SELECT 'INSERT', WorkHoursID,NULL, NULL, NULL, NULL, NULL,
----                EmployeeID, [DATE], TaskID, [Hours], Comments
----        FROM inserted
 
----GO
 
----ALTER TRIGGER TR_WorkHoursUpdate
----ON WorkHours
----FOR UPDATE
----AS
----    INSERT INTO WorkHoursLog
----    SELECT 'UPDATE', d.WorkHoursID, d.EmployeeID, d.[DATE], d.TaskID, d.[Hours], d.Comments,
----    i.EmployeeID, i.[DATE], i.TaskID, i.[Hours], i.Comments  
----    FROM inserted i, deleted d
----GO
 
 
------ TESTING TRIGGERS --
----DELETE FROM WorkHours WHERE WorkHoursID = 3
 
----INSERT INTO WorkHours
----    VALUES(5, '2013-07-12', 4, NULL, NULL)
 
----UPDATE WorkHours
----SET Hours = 123
----FROM WorkHours
----WHERE WorkHoursID = 8;


--TASK 30 Start a database transaction, delete all employees from the 'Sales' department along with 
--all dependent records from the pother tables. At the end rollback the transaction.

----BEGIN TRAN

----ALTER TABLE Departments
----DROP CONSTRAINT FK_Departments_Employees

----DELETE e
----FROM Employees e
----	INNER JOIN Departments d
----		ON e.DepartmentID = d.DepartmentID
----WHERE d.Name = 'Sales'

----ROLLBACK TRAN

--TASK 31 Start a database transaction and drop the table EmployeesProjects. 
--Now how you could restore back the lost table data?

----BEGIN TRAN

----DROP TABLE EmployeesProjects

----ROLLBACK TRAN

--TASK 32 Find how to use temporary tables in SQL Server. Using temporary tables backup 
--all records from EmployeesProjects and restore them back after dropping and re-creating the table.

----CREATE TABLE #EmplProjTemporary (
----	EmployeeID INT,
----	ProjectID INT
----)

----INSERT INTO #EmplProjTemporary
----SELECT p.EmployeeID, p.ProjectID
----FROM EmployeesProjects p

----DROP TABLE EmployeesProjects

----CREATE TABLE EmployeesProjects(
----	EmployeeID int NOT NULL,
----	ProjectID int NOT NULL,
----	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
----	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
----	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
----)

----INSERT INTO EmployeesProjects
----SELECT EmployeeID, ProjectID
----FROM #EmplProjTemporary

