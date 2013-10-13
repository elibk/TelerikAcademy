
---------------
-- Intro SQL --
---------------

---------------
-- Task 4 --
---------------

SELECT * FROM Departments

----OR in details and some more info ----

SELECT
    Departments.DepartmentID,
	Departments.Name,
    COUNT(*) AS EmployeesCount,
	SUM(e.Salary) as ExpencesForSalaries,
	Employees.FirstName + ' ' + Employees.LastName as ManagerName
    
FROM Departments
  INNER JOIN Employees ON Departments.ManagerID = Employees.EmployeeID
  INNER JOIN Employees e ON Departments.DepartmentID = e.DepartmentID 
  
GROUP BY
   Departments.DepartmentID,
   Departments.Name,
   Departments.ManagerID,
   Employees.FirstName + ' ' + Employees.LastName
   
---------------
-- Task 5 --
---------------

SELECT Departments.Name FROM Departments

---------------
-- Task 6 --
---------------

SELECT Employees.FirstName + ' ' + Employees.LastName as Name,  Employees.Salary  FROM Employees

---------------
-- Task 7 --
---------------

SELECT Employees.FirstName, Employees.LastName FROM Employees

---------------
-- Task 8 --
---------------

SELECT Employees.FirstName + '.' + Employees.LastName + '@telerik.com' as [Full Email Addresses] FROM Employees

---------------
-- Task 9 --
---------------

SELECT DISTINCT Employees.Salary as [Salary Values] FROM Employees

---------------
-- Task 10 --
---------------

SELECT * FROM Employees WHERE Employees.JobTitle = 'Sales Representative';

----OR in details and some more info ----

SELECT
    Employees.EmployeeID,
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Employees.JobTitle,
	Departments.Name AS Department,
	e.FirstName + ' ' + e.LastName AS Manager,
	Addresses.AddressText,
	Employees.HireDate,
	Employees.Salary

FROM Employees
  INNER JOIN Departments ON Departments.DepartmentID = Employees.DepartmentID
  INNER JOIN Employees e ON e.EmployeeID = Employees.ManagerID
  INNER JOIN Addresses ON Addresses.AddressID = Employees.AddressID

  WHERE Employees.JobTitle = 'Sales Representative'

---------------
-- Task 11 --
---------------

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName FROM Employees WHERE 
Employees.FirstName LIKE 'SA%'

---------------
-- Task 12 --
---------------

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName FROM Employees WHERE 
Employees.LastName LIKE '%ei%' 
---------------
-- Task 13 --
---------------

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName, Employees.Salary FROM Employees WHERE 
Employees.Salary >= 20000 AND Employees.Salary <= 30000 ;

--OR 

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName, Employees.Salary FROM Employees WHERE 
Employees.Salary BETWEEN 20000 AND 30000;

---------------
-- Task 14 --
---------------
SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName, Employees.Salary FROM Employees WHERE 
Employees.Salary IN (25000, 14000, 12500, 23600);  

---------------
-- Task 15 --
---------------

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName FROM Employees WHERE 
Employees.ManagerID IS NULL; 

---------------
-- Task 16 --
---------------

SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName, Employees.Salary 
	FROM Employees 
	WHERE 
		Employees.Salary >= 50000
	ORDER BY Employees.Salary DESC;
	
	
---------------
-- Task 17 --
---------------

SELECT TOP 5 Employees.FirstName, Employees.MiddleName, Employees.LastName, Employees.Salary 
	FROM Employees 
	ORDER BY Employees.Salary DESC;
	
---------------
-- Task 18 --
---------------

SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Addresses.AddressText

FROM Employees

  INNER JOIN Addresses ON Addresses.AddressID = Employees.AddressID

---------------
-- Task 19 --
---------------

SELECT   
	Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Addresses.AddressText 
FROM Employees, Addresses 
	WHERE Employees.AddressID = Addresses.AddressID;
  
  
---------------
-- Task 20 --
---------------
 
SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Employees.JobTitle,
	e.FirstName + ' ' + e.LastName AS Manager
FROM Employees

  LEFT JOIN Employees e ON e.EmployeeID = Employees.ManagerID

---------------
-- Task 21 --
---------------
 
SELECT 
    e.EmployeeID,
    e.FirstName,
	e.MiddleName,
	e.LastName,
	e.JobTitle,
	m.FirstName + ' ' + m.LastName AS Manager,
	a.AddressText

FROM Employees e
  LEFT JOIN Employees m ON m.EmployeeID = e.ManagerID
  LEFT JOIN Addresses a ON a.AddressID = e.AddressID


---------------
-- Task 22 --
---------------
  
SELECT Departments.Name FROM Departments
UNION
SELECT Towns.Name FROM Towns

---------------
-- Task 23 --
---------------
  
SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Employees.JobTitle,
	e.FirstName + ' ' + e.LastName AS Manager
FROM Employees

  LEFT  JOIN Employees e ON e.EmployeeID = Employees.ManagerID  
------------------- 
SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Employees.JobTitle,
	e.FirstName + ' ' + e.LastName AS Manager
FROM Employees

RIGHT OUTER JOIN Employees e ON e.EmployeeID = Employees.ManagerID  
  
---------------
-- Task 24 --
---------------
    
 SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName
	
FROM Employees

	WHERE 
	Employees.DepartmentID = (SELECT TOP 1 DepartmentID FROM Departments WHERE Name IN ('Sales', 'Finance')) AND
	(YEAR(Employees.HireDate)  BETWEEN 1995 AND 2005); 
  
  
  
  




