------------------- T-SQL ---------------------

--------------------------
-------- task 01 ---------
--------------------------
CREATE PROC usp_SelectPersonsFullName
AS
BEGIN
  SELECT 
	CASE
		WHEN p.FirstName IS NOT NULL THEN p.FirstName + ' ' + p.LastName
		ELSE p.LastName 
	END AS [Full Name]
FROM
  Persons p
END
GO
---------------------------
EXEC usp_SelectPersonsFullName

--------------------------
-------- task 02 ---------
--------------------------

CREATE PROC usp_SelectPeopleWithMoreMoney(@moneyInAccount money)
AS
BEGIN
  SELECT 
	CASE
		WHEN p.FirstName IS NOT NULL THEN p.FirstName + ' ' + p.LastName
		ELSE p.LastName 
	END AS [Owner],
	a.Balance
FROM
  Accounts a
  INNER JOIN Persons p ON a.OwnerID = p.PersonID

WHERE a.Balance > @moneyInAccount 
END
GO
--------------------
EXEC usp_SelectPeopleWithMoreMoney 1000


--------------------------
-------- task 03 ---------
--------------------------
CREATE FUNCTION ufn_CalcNewBalnce(@currentSum money, @yearlyInterestRate money,  @months int)
  RETURNS money
AS
	BEGIN
		RETURN @currentSum * (((@yearlyInterestRate / 12) * @months) + 1)
	END
GO
--------------------------------
SELECT 
	a.Balance as [Old sum],
	dbo.ufn_CalcNewBalnce(a.Balance, 0.12, 5) as [New sum]
FROM
  Accounts a
  
--------------------------
-------- task 04 ---------
--------------------------
ALTER FUNCTION ufn_CalcIntrestForOneMonth(@yearlyInterestRate money, @accountID int)
RETURNS money
AS
BEGIN
DECLARE @interest money;

	 SELECT @interest = dbo.ufn_CalcNewBalnce(a.Balance, @yearlyInterestRate, 1) - a.Balance
	FROM
	  Accounts a
	  WHERE a.AccountID = @accountID

	  return @interest
END
GO

SELECT 

a.Balance,
dbo.ufn_CalcIntrestForOneMonth(0.12, a.AccountID) as [Interest form 1 month 12 % yearly interest rate ]

FROM Accounts a

--------------------------
-------- task 05 ---------
--------------------------

CREATE PROC usp_WithdrawMoney(@money money, @accountID int)
AS
DECLARE @moneyInBalance money;
BEGIN
	BEGIN TRAN
		UPDATE Accounts SET Balance = Balance - @money WHERE AccountID= @accountID;
		SELECT @moneyInBalance = a.Balance 
		FROM
		  Accounts a
		  WHERE a.AccountID = @accountID
		IF @moneyInBalance < 0
		BEGIN
		RAISERROR('There are not enough money in the account.', 16, 1)
		ROLLBACK TRAN
		END
		ELSE
		COMMIT TRAN
END
GO

EXEC usp_WithdrawMoney 1000, 100
EXEC usp_WithdrawMoney 1000, 1000

SELECT * FROM Accounts

------------------------------

ALTER PROC usp_DepositMoney (@money money, @accountID int)
AS
DECLARE @moneyInBalance money;

BEGIN TRAN
		UPDATE Accounts SET Balance = Balance + @money WHERE AccountID= @accountID;
		SELECT @moneyInBalance = a.Balance 
		FROM
		  Accounts a
		  WHERE a.AccountID = @accountID
		IF @@ROWCOUNT = 0
		BEGIN
		RAISERROR('The operation was not performed.', 16, 1)
		ROLLBACK TRAN
		END
		ELSE
		COMMIT TRAN
GO

EXEC usp_DepositMoney 50, 1000

SELECT * FROM Accounts

--------------------------
-------- task 06 ---------
--------------------------

CREATE TABLE Logs(
        LogId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        AccountID int NOT NULL FOREIGN KEY REFERENCES Accounts(AccountID),
        OldSum money NOT NULL,
		NewSum money NOT NULL,
);

----------------------------------------------------

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @oldSum money;
	DECLARE @newSum money;
	DECLARE @accountID int;

    SELECT @oldSum = deleted.Balance FROM deleted
    SELECT @newSum = inserted.Balance FROM inserted
	SELECT @accountID = inserted.AccountID FROM inserted

	INSERT INTO Logs(AccountID, oldSum, newSum) VALUES(@accountID, @oldSum, @newSum)
END 
GO

--------------------------------------------------

EXEC usp_WithdrawMoney 5, 1000

SELECT * FROM Accounts

--------------------------
-------- task 07 ---------
--------------------------

CREATE FUNCTION ufn_CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
BEGIN

	DECLARE @lettersLen int = LEN(@letters),
	@startIndex int = 1,
	@currentChar nvarchar(1)

		WHILE(@lettersLen > 0)
			BEGIN
			SET @currentChar = SUBSTRING(@word, @startIndex, 1)
			IF(CHARINDEX(@currentChar, @letters) > 0)
				BEGIN
					SET @lettersLen -= 1
					SET @startIndex += 1
				END
			ELSE
			BEGIN
			RETURN 0
			END
		END
	RETURN 1
END

GO

CREATE PROC ufn_SelectNamesAndTowns (@sequenceOfLetters nvarchar(20))
AS

BEGIN
	SELECT e.FirstName FROM Employees e
	WHERE dbo.ufn_CheckIfHasLetters(e.FirstName, @sequenceOfLetters) = 1

END

GO


EXEC ufn_SelectNamesAndTowns 'onjas'






