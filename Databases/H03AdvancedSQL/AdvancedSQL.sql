-------------------------
------ Advanced SQL -----
-------------------------

--------------------
------ Task 01 -----
--------------------

SELECT 
	e.FirstName,
	e.MiddleName,
	e.LastName,
	e.Salary

FROM Employees e
	WHERE 
	e.Salary = (SELECT MIN(emp.Salary) FROM Employees emp)
	
--------------------
------ Task 02 -----
--------------------

SELECT 
	e.FirstName,
	e.MiddleName,
	e.LastName,
	e.Salary

FROM Employees e
	WHERE 
	e.Salary <= (SELECT MIN(emp.Salary) FROM Employees emp)* 1.1 
	
--------------------
------ Task 03 -----
--------------------
	
SELECT
  e.FirstName + ' ' +
  CASE WHEN e.MiddleName IS NOT NULL THEN e.MiddleName +' '  + e.LastName
  ELSE e.LastName END AS [Full Name],
  e.Salary,
  Departments.Name AS DepartmentName
FROM
  Employees e
   INNER JOIN Departments ON e.DepartmentID = Departments.DepartmentID
  WHERE
	e.Salary = (SELECT MIN(emp.Salary) FROM Employees emp WHERE emp.DepartmentID = e.DepartmentID)
	
	
--------------------
------ Task 04 -----
--------------------

SELECT
 AVG(e.Salary) AS AverageSalaryDepartment#1
FROM
  Employees e
  WHERE
	e.DepartmentID = 1
	
--------------------
------ Task 05 -----
--------------------

SELECT
 AVG(e.Salary) AS AverageSalaryDepartmentSales
FROM
  Employees e
  WHERE
	e.DepartmentID = (SELECT DepartmentID from Departments where Name = 'Sales')

--------------------
------ Task 06 -----
--------------------

SELECT
 COUNT(*) AS [Count of employees in Sales department]
FROM
  Employees e
  WHERE
	e.DepartmentID = (SELECT DepartmentID from Departments where Name = 'Sales')

--------------------
------ Task 07 -----
--------------------
	
SELECT
 COUNT(*) AS [Count of employees with manager]
FROM
  Employees e
  WHERE
	e.ManagerID IS NOT NULL
	
--------------------
------ Task 08 -----
--------------------

SELECT
 COUNT(*) AS [Count of employees with manager]
FROM
  Employees e
  WHERE
	e.ManagerID IS NULL
	
--------------------
------ Task 09 -----
--------------------

SELECT
  Departments.Name AS DepartmentName,
  AVG(E.Salary) AS AverageSalary
FROM
  Employees e
   INNER JOIN Departments ON e.DepartmentID = Departments.DepartmentID
 GROUP BY Departments.Name
 
--------------------
------ Task 10 -----
--------------------

SELECT	
COUNT(*) as EmployeesCount,
Departments.Name as DepartmentName,
Towns.Name as Town
FROM Employees e
		INNER JOIN Departments
			ON Departments.DepartmentID = e.DepartmentID
		Inner JOIN
		(
			Addresses 
				INNER JOIN Towns
					ON Towns.TownID = Addresses.TownID
					
		)
			ON e.AddressID = Addresses.TownID
GROUP BY
Departments.Name,
Towns.Name
ORDER BY Departments.Name

--------------------
------ Task 11 -----
--------------------

SELECT	
m.FirstName + ' ' + m.LastName as Manager,
COUNT(*) as EmployeesCount

FROM Employees e
		INNER JOIN Employees m
			ON m.EmployeeID = e.ManagerID
GROUP BY
m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5

--------------------
------ Task 12 -----
--------------------

SELECT
    Employees.FirstName,
	Employees.MiddleName,
	Employees.LastName,
	Employees.JobTitle,
	CASE WHEN e.FirstName + ' ' + e.LastName IS NULL THEN '(no manager)'
	ELSE e.FirstName + ' ' + e.LastName END AS Manager
	
FROM Employees

  LEFT JOIN Employees e ON e.EmployeeID = Employees.ManagerID
  
--------------------
------ Task 13 -----
--------------------
SELECT
  e.FirstName + ' ' +
  CASE WHEN e.MiddleName IS NOT NULL THEN e.MiddleName +' '  + e.LastName
  ELSE e.LastName END AS [Full Name]
FROM
  Employees e
  WHERE
	LEN(e.LastName) = 5
	
--------------------
------ Task 14 -----
--------------------

SELECT CONVERT(VARCHAR(24),GETDATE(),113) AS [CURRENT DATE AND TIME];
----------------------------------------------------------------------------------------------------
--------------------
------ Task 15 -----
--------------------

CREATE TABLE Users (
	userId int IDENTITY,
	username nvarchar(50) NOT NULL,
	userpass nvarchar(50) NOT NULL,
	fullName nvarchar(50),
	lastLogin datetime DEFAULT GETDATE(),
	CONSTRAINT PK_Users PRIMARY KEY(userId),
	UNIQUE(username),
	CONSTRAINT userpass CHECK (LEN(userpass) > 5)
)
GO

INSERT INTO Users VALUES ('pesho', 'peshopass', 'Pesho Pesho', GETDATE())
INSERT INTO Users VALUES ('sotir', 'sotirpass', 'Sotir Sotir', GETDATE())
INSERT INTO Users VALUES ('gosho', 'goshopass', 'Gosho Gosho', '2013-07-11')
GO

--------------------
------ Task 16 -----
--------------------
CREATE VIEW  [Today logged in Users] AS
SELECT Username
FROM Users
WHERE DATEDIFF(day,LastLogin,GETDATE()) < 1

--------------------
------ Task 17 -----
--------------------
CREATE TABLE Groups(
	name nvarchar(50) NOT NULL
	UNIQUE(name),
	CONSTRAINT PK_Groups PRIMARY KEY(name)
)
GO
--------------------
------ Task 18 -----
--------------------
ALTER TABLE Users
ADD GroupId nvarchar(50)
GO 

ALTER TABLE Users
ADD FOREIGN KEY(GroupId) REFERENCES Groups(name)
--------------------
------ Task 19 -----
--------------------
INSERT INTO Groups VALUES ('Group 1')
INSERT INTO Groups VALUES ('Group 2')
INSERT INTO Groups VALUES ('Group 3')


--------------------
------ Task 20 -----
--------------------

UPDATE Users SET GroupId = 'Group 1' WHERE userId = 1
UPDATE Users SET GroupId = 'Group 2' WHERE userId = 2
UPDATE Users SET GroupId = 'Group 3' WHERE userId = 3
--------------------
------ Task 21 -----
--------------------
DELETE FROM Users WHERE userId = 3
DELETE FROM Groups WHERE name = 'Group 1' -- will throw error, due to FK constraint
--------------------
------ Task 22 -----
--------------------
ALTER TABLE Users ALTER COLUMN lastLogin datetime NULL -- Alter the not null constraint in users (just to be sure)

INSERT INTO Users (username, userpass, fullName, lastLogin)
	SELECT 
		LOWER(LEFT(FirstName,1)) + LOWER(LEFT(LastName,1)) + CONVERT(nvarchar(50), EmployeeID), -- we have a uniqueness constraint for the username
		LOWER(LEFT(FirstName,2)) + LOWER(LEFT(LastName,3)) + CONVERT(nvarchar(50), EmployeeID), -- we have a constraint for at least 5 chars for password
		FirstName + ' ' + LastName,
		NULL 
	FROM Employees
--------------------
------ Task 23 -----
--------------------
INSERT INTO Users VALUES ('gosho1', 'goshopass1', 'Gosho Gosho 1', '2010-02-11', NULL)
INSERT INTO Users VALUES ('gosho2', 'goshopass2', 'Gosho Gosho 2', '2010-02-12', NULL)

UPDATE Users SET userpass = NULL
WHERE lastLogin < '20100310'
--------------------
------ Task 24 -----
--------------------


--------------------
------ Task 25 -----
--------------------
SELECT
  e.JobTitle,
  Departments.Name AS DepartmentName,
  AVG(e.Salary) AS AverageSalary
FROM
  Employees e
   INNER JOIN Departments ON e.DepartmentID = Departments.DepartmentID
GROUP BY
e.JobTitle,
Departments.Name
ORDER BY e.JobTitle

--------------------
------ Task 26 -----
--------------------

SELECT
  Departments.Name AS DepartmentName,
   Min(e.Salary) AS MinSalary,
   Min(e.employeeName) as EmployeeWithMinSalary
FROM
  (SELECT minSalary.FirstName + ' ' + minSalary.LastName AS employeeName,
  DepartmentID,
  Salary
     FROM Employees minSalary
) e
  INNER JOIN Departments ON e.DepartmentID = Departments.DepartmentID
GROUP BY
Departments.Name
ORDER BY Departments.Name

--------------------
------ Task 27 -----
--------------------

SELECT	
e.Town as [Town with large number of employees] 
	FROM 
	(
		SELECT COUNT(*) as EmployeesCount,
				Towns.Name as Town
		FROM Employees emp 
			INNER JOIN
				(
					Addresses 
						INNER JOIN Towns
							ON Towns.TownID = Addresses.TownID
					
				)
				ON emp.AddressID = Addresses.TownID
		GROUP BY
		Towns.Name
	) e 
	WHERE
		e.EmployeesCount = 
			(	
				Select 
					MAX(emp.EmployeesCount) 
						FROM 
						(
							SELECT 
								COUNT(*) as EmployeesCount,
								Towns.Name as Town
							FROM Employees emp 
								Inner JOIN
								(
									Addresses 
										INNER JOIN Towns
											ON Towns.TownID = Addresses.TownID
					
								)
								ON emp.AddressID = Addresses.TownID
							GROUP BY
							Towns.Name
						) emp
	)
	
--- or----

SELECT TOP 1 t.Name ,COUNT(*) as EmployeesCount
FROM Employees e JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t 
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY EmployeesCount DESC
	
--------------------
------ Task 28 -----
--------------------


SELECT t.Name ,COUNT(*) as ManagersCount
FROM 
(
		SELECT DISTINCT

		m.AddressID AS ManagerAddressID,
		m.EmployeeID AS ManagerID

		FROM Employees
		  INNER JOIN Employees m ON m.EmployeeID = Employees.ManagerID
	) managers  
JOIN Addresses a ON managers.ManagerAddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY ManagersCount 

--------------------
------ Task 29 -----
--------------------

CREATE TABLE WorkHours(
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
        ReportDate date NOT NULL,
        Task nvarchar(80) NOT NULL,
        ExecutionHours float NOT NULL CHECK(Len(ExecutionHours)>=0),
        Comments nvarchar(255) NOT NULL
);

INSERT WorkHours VALUES('1', GETDATE(), 'Clean the pool', '2.5', 'Good job');
INSERT WorkHours VALUES('2', GETDATE(), 'Wash the windows', '1', 'Great job');
UPDATE WorkHours SET Comments = 'Perfect Job' WHERE WorkHours.EmployeeId = 2;
DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
INSERT WorkHours VALUES('1', GETDATE(), 'Clean the pool', '2.5', 'Good job');


CREATE TABLE WorkHoursLogs(
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        OldEmployeeId int NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
		NewEmployeeId int NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
        OldReportDate date NULL,
		NewReportDate date NULL,
        OldTask nvarchar(80) NULL,
		NewTask nvarchar(80) NULL,
        OldExecutionHours float NULL,
		NewExecutionHours float NULL,
        OldComments nvarchar(255) NULL,
		NewComments nvarchar(255) NULL,
		Command nvarchar(50) NULL
);

CREATE TRIGGER WorkHoursAfterInsert ON dbo.WorkHours AFTER INSERT AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		'INSERT'
	);
END
GO

INSERT WorkHours VALUES('1', GETDATE(), 'Cleaning the pool', '2.5', 'Good job');

SELECT * FROM WorkHoursLogs;

CREATE TRIGGER WorkHoursAfterUpdate ON dbo.WorkHours AFTER UPDATE AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255),
		@OldEmployeeId int, 
		@OldReportDate date, 
		@OldTask nvarchar(80),
		@OldExecutionHours float, 
		@OldComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;

		SELECT 
		@OldEmployeeId = deleted.EmployeeId, 
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task, 
		@OldExecutionHours = deleted.ExecutionHours, 
		@OldComments = deleted.Comments
	FROM deleted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		OldEmployeeId, 
		OldReportDate, 
		OldTask,
		OldExecutionHours, 
		OldComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		@OldEmployeeId, 
		@OldReportDate, 
		@OldTask, 
		@OldExecutionHours, 
		@OldComments, 
		'UPDATE'
	);
END
GO

UPDATE WorkHours SET Comments = 'Perfect Job' WHERE WorkHours.EmployeeId = 1;
SELECT * FROM WorkHoursLogs;

CREATE TRIGGER WorkHoursAfterDelete ON dbo.WorkHours AFTER DELETE AS
BEGIN
	DECLARE 
		@NewEmployeeId int, 
		@NewReportDate date, 
		@NewTask nvarchar(80),
		@NewExecutionHours float, 
		@NewComments nvarchar(255),
		@OldEmployeeId int, 
		@OldReportDate date, 
		@OldTask nvarchar(80),
		@OldExecutionHours float, 
		@OldComments nvarchar(255);
 
	SELECT 
		@NewEmployeeId = inserted.EmployeeId, 
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task, 
		@NewExecutionHours = inserted.ExecutionHours, 
		@NewComments = inserted.Comments
	FROM inserted;

		SELECT 
		@OldEmployeeId = deleted.EmployeeId, 
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task, 
		@OldExecutionHours = deleted.ExecutionHours, 
		@OldComments = deleted.Comments
	FROM deleted;
 
	INSERT INTO WorkHoursLogs (
		NewEmployeeId, 
		NewReportDate, 
		NewTask,
		NewExecutionHours, 
		NewComments, 
		OldEmployeeId, 
		OldReportDate, 
		OldTask,
		OldExecutionHours, 
		OldComments, 
		Command
	)
	VALUES (
		@NewEmployeeId, 
		@NewReportDate, 
		@NewTask, 
		@NewExecutionHours, 
		@NewComments, 
		@OldEmployeeId, 
		@OldReportDate, 
		@OldTask, 
		@OldExecutionHours, 
		@OldComments, 
		'DELETE'
	);
END
GO

DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
SELECT * FROM WorkHoursLogs;

--------------------
------ Task 30 -----
--------------------
ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Addresses_Cascade;

ALTER TABLE dbo.Employees
   ADD CONSTRAINT FK_Employees_Addresses_Cascade
   FOREIGN KEY (AddressID) REFERENCES dbo.Addresses(AddressID) ON DELETE CASCADE;
   
ALTER TABLE dbo.Employees DROP CONSTRAINT FK_Employees_Departments_Cascade;

ALTER TABLE dbo.Employees
   ADD CONSTRAINT FK_Employees_Departments_Cascade
   FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID) ON DELETE CASCADE;

ALTER TABLE dbo.EmployeesProjects DROP CONSTRAINT FK_EmployeesProjects_Employees;

ALTER TABLE dbo.EmployeesProjects
   ADD CONSTRAINT FK_EmployeesProjects_Employees_Cascade
   FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID) ON DELETE CASCADE;

BEGIN TRAN DeleteEmployee

DELETE FROM Employees WHERE Employees.EmployeeID = 5;

ROLLBACK TRAN

--------------------
------ Task 31 -----
--------------------
BEGIN TRAN
 
DROP TABLE EmployeesProjects
 
ROLLBACK TRAN

--------------------
------ Task 32 -----
--------------------
BEGIN TRAN
        SELECT 
			* 
		INTO #EmployeesProjects_Archive
        FROM 
			EmployeesProjects;

        DROP TABLE EmployeesProjects;

        SELECT 
			* 
		INTO EmployeesProjects
        FROM 
			#EmployeesProjects_Archive;

        DROP TABLE #EmployeesProjects_Archive;
GO


	

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	