-- REMOVE '----' from each task and execute with F5

--TASK 4 Write a SQL query to find all information about all departments.
----SELECT * FROM Departments

--TASK 5 Write a SQL query to find all department names.
----SELECT Name FROM Departments

--TASK 6 Write a SQL query to find the salary of each employee.
----SELECT FirstName, LastName, Salary 
----FROM Employees

--TASK 7 Write a SQL to find the full name of each employee.
----SELECT FirstName, LastName, MiddleName
----FROM Employees

--TASK 8 Write a SQL query to find the email addresses of each employee 
--(by his first and last name). Consider that the mail domain is telerik.com. 
--Emails should look like “John.Doe@telerik.com". The produced column should 
--be named "Full Email Addresses".
----SELECT FirstName, LastName, FirstName + '.' + LastName + '@telerik.com' AS Emails
----FROM Employees

--TASK 9 Write a SQL query to find all different employee salaries.
----SELECT 
	----DISTINCT Salary
----FROM Employees

--TASK 10 Write a SQL query to find all information about the employees whose job title 
--is “Sales Representative“.
----SELECT *
----FROM Employees
----WHERE JobTitle = 'Sales Representative'

--TASK 11 Write a SQL query to find the names of all employees whose first name starts with "SA".
----SELECT FirstName, LastName
----FROM Employees
----WHERE FirstName LIKE 'SA%'

--TASK 12 Write a SQL query to find the names of all employees whose last name contains "ei".
----SELECT FirstName, LastName
----FROM Employees
----WHERE LastName LIKE '%ei%'

--TASK 13 Write a SQL query to find the salary of all employees whose salary 
--is in the range [20000…30000].
----SELECT FirstName, LastName, Salary
----FROM Employees
----WHERE Salary BETWEEN 20000 AND 30000

--TASK 14 Write a SQL query to find the names of all employees whose salary is 25000, 14000, 
--12500 or 23600.
----SELECT FirstName, LastName, Salary
----FROM Employees
----WHERE Salary IN (25000, 14000, 12500, 23600)

--TASK 15 Write a SQL query to find all employees that do not have manager.
----SELECT FirstName, LastName, ManagerID
----FROM Employees
----WHERE ManagerID IS Null

--TASK 16 Write a SQL query to find all employees that have salary more than 50000. 
--Order them in decreasing order by salary.
----SELECT FirstName, LastName, Salary
----FROM Employees
----WHERE Salary > 50000
----ORDER BY Salary DESC

--TASK 17 Write a SQL query to find the top 5 best paid employees.
----SELECT TOP 5 FirstName, LastName, Salary
----FROM Employees
----ORDER BY SALARY DESC

--TASK 18 Write a SQL query to find all employees along with their address. 
--Use inner join with ON clause.
----SELECT e.EmployeeID, e.FirstName, e.LastName, a.AddressText
----FROM Employees e
	----INNER JOIN Addresses a
		----ON e.AddressID = a.AddressID

--TASK 19 Write a SQL query to find all employees and their address. 
--Use equijoins (conditions in the WHERE clause).
----SELECT e.EmployeeID, e.FirstName, e.LastName, a.AddressText
----FROM Employees e, Addresses a
----WHERE e.AddressID = a.AddressID

--TASK 20 Write a SQL query to find all employees along with their manager.
----SELECT e.FirstName [Empl First Name], e.LastName [Empl Last Name],
----m.EmployeeID [Mngr ID], m.FirstName [Mngr First Name], m.LastName [Mngr Last Name]
----FROM Employees e INNER JOIN Employees m
	----ON e.ManagerID = m.EmployeeID 

--TASK 21 Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a.
----SELECT e.EmployeeID, e.FirstName [Empl FirstName], e.LastName [Empl LastName],
----m.EmployeeID [Mngr ID], m.FirstName[Mngr FirstName], m.LastName[Mngr LastName],
----a.AddressText
----FROM Employees e 
	----INNER JOIN Employees m
		----ON e.ManagerID = m.EmployeeID
	----INNER JOIN Addresses a
		----ON e.AddressID = a.AddressID
		
--TASK 22 Write a SQL query to find all departments and all town names as a single list. Use UNION.
----SELECT Name FROM Towns
----UNION
----SELECT Name FROM Departments

--TASK 23 Write a SQL query to find all the employees and the manager for each of them along with 
--the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
----SELECT e.EmployeeID, e.FirstName, e.LastName,
----m.EmployeeID [Mngr ID], m.FirstName, m.LastName
----FROM Employees e
	----LEFT OUTER JOIN Employees m
		----ON e.ManagerID = m.EmployeeID

--TASK 24 Write a SQL query to find the names of all employees from the 
--departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name [Dep Name], YEAR (e.HireDate)
FROM Employees e 
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance')
	AND (YEAR (e.HireDate)) BETWEEN 1995 AND 2005














