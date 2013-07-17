
--TASK 1 Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.

----CREATE DATABASE T_SQL_TestDB

----CREATE TABLE Persons (
----	Id INT PRIMARY KEY IDENTITY,
----	FirstName NVARCHAR(50),
----	LastName NVARCHAR(50),
----	SSN VARCHAR(50)
----)

----CREATE TABLE Accounts (
----	Id INT PRIMARY KEY IDENTITY,
----	PersonaId INT FOREIGN KEY REFERENCES Persons(Id),
----	Balance MONEY 
----)

----INSERT INTO Persons
----	VALUES ('Petio', 'Petkov', '564521422')
----INSERT INTO Persons
----	VALUES ('Kolio', 'Kolev', '546548421')
----INSERT INTO Accounts
----	VALUES ('1', '455511')
----INSERT INTO Accounts
----	VALUES ('2', '4564456')

----GO

----CREATE PROC usp_SelectFullNames
----AS
----	SELECT FirstName + ' ' + LastName
----	FROM Persons
----GO

----EXEC usp_SelectFullNames

--TASK 2 Create a stored procedure that accepts a number as a parameter and 
--returns all persons who have more money in their accounts than the supplied number.

----CREATE PROC usp_ReturnPersonIfBallanceBiggerThan(@number money)
----AS
----	SELECT p.FirstName, p.LastName
----	FROM Persons p
----		INNER JOIN Accounts a
----			ON p.Id = a.PersonId
----	WHERE a.Balance > @number
----GO

----EXEC usp_ReturnPersonIfBallanceBiggerThan 455512

--TASK 3 Create a function that accepts as parameters – sum, yearly interest rate and 
--number of months. It should calculate and return the new sum. Write a SELECT to 
--test whether the function works as expected.

----CREATE FUNCTION fn_SumAfterInterestRate (@sum money, @rate float, @months int)
----	RETURNS money
----AS
----BEGIN
----	SET @sum = @sum + @sum * (@rate/100)
----	RETURN @sum
----END

----GO

----SELECT dbo.fn_SumAfterInterestRate (200, 6, 6)

--TASK 4 Create a stored procedure that uses the function from the previous example 
--to give an interest to a person's account for one month. It should take the AccountId and 
--the interest rate as parameters.

----CREATE PROC usp_RateForMonth (@accId int, @rate float)
----AS
----	SELECT a.Id as AccountId, dbo.fn_SumAfterInterestRate(a.Balance, @rate, 1)
----	FROM Accounts a
----		INNER JOIN Persons p
----			ON a.PersonId = p.Id
----	WHERE a.Id = @accId 
----GO

----EXEC usp_RateForMonth 1, 3

--TASK 5 Add two more stored procedures WithdrawMoney( AccountId, money) and 
--DepositMoney (AccountId, money) that operate in transactions.

----ALTER PROC usp_WithdrawMoney (@AccountId int, @money money)
----AS
----	UPDATE Accounts
----	SET Balance = Balance - @money
----	WHERE Balance >= @money AND Id = @AccountId
----GO

----ALTER PROC usp_DepositMoney (@AccountId int, @money money)
----AS
----	UPDATE Accounts
----	SET Balance = Balance + @money
----	WHERE Id = @AccountId
----GO

----BEGIN TRAN

----EXEC usp_WithdrawMoney 1, 500

----ROLLBACK TRAN

----BEGIN TRAN

----EXEC usp_DepositMoney 2, 200

----ROLLBACK TRAN

--TASK 6 Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs 
--table every time the sum on an account changes.

----CREATE TABLE Logs (
----	LogID INT PRIMARY KEY IDENTITY,
----	AccountID INT FOREIGN KEY REFERENCES Accounts(Id),
----	OldSum MONEY,
----	NewSum MONEY
----)

----GO

----CREATE TRIGGER tr_AccountsUpdate ON Accounts AFTER UPDATE
----NOT FOR REPLICATION
----AS
----	DECLARE @id INT, @oldBal MONEY, @newBal MONEY
----	SELECT @id = ins.Id, @oldBal = del.Balance, @newBal = ins.Balance
----	FROM deleted del
----		INNER JOIN inserted ins
----			ON del.Id = ins.Id
----    BEGIN
----      INSERT INTO Logs(AccountID, OldSum, NewSum)
----	  SELECT @id, @oldBal, @newBal
----    END
----GO

----EXEC usp_DepositMoney 2, 200

--TASK 7 NOT-COMPLETED Define a function in the database TelerikAcademy that returns all Employee's names 
--(first or middle or last name) and all town's names that are comprised of given set of letters. 
--Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

----CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
----RETURNS BIT
----AS
----BEGIN

----DECLARE @lettersLen int = LEN(@letters),
----@matches int = 0,
----@currentChar nvarchar(1)

----WHILE(@lettersLen > 0)
----BEGIN
----	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
----	IF(CHARINDEX(@currentChar, @word, 0) > 0)
----		BEGIN
----			SET @matches += 1
----			SET @lettersLen -= 1
----		END
----	ELSE
----		SET @lettersLen -= 1
----END

----IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
----	RETURN 1

----RETURN 0
----END

----GO

----CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
----RETURNS @ResultTable TABLE
----(
----Name varchar(50) NOT NULL
----)
----AS
----BEGIN

----INSERT INTO @ResultTable
----SELECT LastName  FROM Employees

----INSERT INTO @ResultTable
----SELECT FirstName FROM Employees

----INSERT INTO @ResultTable
----SELECT towns.Name FROM Towns towns

----DELETE FROM @ResultTable
----WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

----RETURN
----END

----GO

----SELECT * FROM dbo.NamesAndTowns('oistmiahf')

--TASK 8 Using database cursor write a T-SQL script that scans all employees and their addresses 
--and prints all pairs of employees that live in the same town.

----DECLARE empCursor CURSOR READ_ONLY FOR
----  SELECT e.FirstName, e.LastName, t.Name
----  FROM Employees e
----	INNER JOIN Addresses ad
----		ON e.AddressID = ad.AddressID
----	INNER JOIN Towns t
----		ON ad.TownID = t.TownID

----OPEN empCursor
----DECLARE @firstName char(50), @lastName char(50), @townName char(50)
----FETCH NEXT FROM empCursor INTO @firstName, @lastName, @townName

----WHILE @@FETCH_STATUS = 0
----  BEGIN
----    PRINT @firstName + ' ' + @lastName + ' ' + @townName
----    FETCH NEXT FROM empCursor 
----    INTO @firstName, @lastName, @townName
----  END

----CLOSE empCursor
----DEALLOCATE empCursor
