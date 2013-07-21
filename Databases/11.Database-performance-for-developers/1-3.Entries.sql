--1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
--Search in the table by date range. Check the speed (without caching).
 
DECLARE @counter INT
SET @counter = 0

DECLARE @date SMALLDATETIME, @text NVARCHAR(MAX)
SET @date = GETDATE()
SET @text = 'Lorem ' + CONVERT(nvarchar(100), newid())

--Execute it once
WHILE (@counter < 100000)
	BEGIN
		SET @date = DATEADD(hour,1,@date)
		INSERT INTO Entries(Date, Text)
		VALUES (@date, @text)
		SET @counter = @counter + 1
	END

--Execute it several times until the rows reach 10 000 000
Set @counter = 0
while @counter < 7
begin
	INSERT INTO Entries(Date, Text)
	SELECT Date, Text
	FROM Entries
end

--Search in date range
DECLARE @startDate SMALLDATETIME = '2013-06-01 00:00:00';
DECLARE @endDate SMALLDATETIME = '2013-09-01 00:00:00';

SELECT *
FROM Entries
WHERE Date BETWEEN @startDate AND @endDate
-- -- takes 45sec

--2. Search when Date indexed with and without cache cleaning
CREATE INDEX IDX_Entires_Date ON Entries(Date)

SELECT * FROM Entries
WHERE Date BETWEEN @startDate AND @endDate
-- -- takes 26sec

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--3. Add a full text index for the text column. 
--Try to search with and without the full-text index and compare the speed.
DROP INDEX IDX_Entires_Date ON Entries

CREATE FULLTEXT CATALOG EntriesFullTextCatalog

CREATE FULLTEXT INDEX ON Entries(Text)
KEY INDEX PK_Text
ON LogFullText
WITH CHANGE_TRACKING AUTO

SELECT TOP 10000 *
FROM Entries
WHERE CONTAINS(Text,'Lorem')