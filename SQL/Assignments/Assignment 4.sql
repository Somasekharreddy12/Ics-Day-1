use Assignments

Begin transaction  t1
DECLARE @Number INT;          
DECLARE @Factorial BIGINT = 1; 
DECLARE @Counter INT = 1;       
 
PRINT 'Enter a number to find its factorial:';
SET @Number = 7;  
 

IF @Number < 0
BEGIN
    PRINT 'Factorial is not defined for negative numbers.';
END
ELSE
BEGIN
   
    WHILE @Counter <= @Number
    BEGIN
        SET @Factorial = @Factorial * @Counter;
        SET @Counter = @Counter + 1;
    END
 
    
    PRINT 'The factorial of ' + CAST(@Number AS VARCHAR) + ' is ' + CAST(@Factorial AS VARCHAR) + '.';
END

commit transaction t1;

-----------------------------------------------------------------------------------------------------------------------------------------------------



CREATE PROCEDURE Multiplication__Table
    @Number INT,       -- The number for which the multiplication table is generated
    @Limit INT         -- The upper limit for the multiplication table
AS
BEGIN
    -- Declare variables
    DECLARE @Counter INT = 1;
 
    PRINT 'Multiplication Table for ' + CAST(@Number AS VARCHAR);
 
    -- Generate the multiplication table using a WHILE loop
    WHILE @Counter <= @Limit
    BEGIN
        PRINT CAST(@Number AS VARCHAR) + ' x ' + CAST(@Counter AS VARCHAR) + ' = ' + CAST(@Number * @Counter AS VARCHAR);
        SET @Counter = @Counter + 1;
    END
END;

exec Multiplication__Table @Number = 7,@limit = 10;

------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Step 1: Create the Function
Create FUNCTION GetStudentStatus(@Score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    RETURN 
        WHEN @Score >= 50 THEN 'Pass'
        ELSE 'Fail'
    END;
END;
 
-- Step 2: Create the Student Table
CREATE TABLE Student (
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);
 
-- Step 3: Insert Data into Student Table
INSERT INTO Student (Sid, Sname)
VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');
 
-- Step 4: Create the Marks Table
CREATE TABLE Marks (
    Mid INT PRIMARY KEY,
    Sid INT FOREIGN KEY REFERENCES Student(Sid),
    Score INT
);
 
-- Step 5: Insert Data into Marks Table
INSERT INTO Marks (Mid, Sid, Score)
VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);
 
-- Step 6: Query to Display Data with Status
SELECT
    s.Sid AS StudentID,
    s.Sname AS StudentName,
    m.Score AS StudentScore,
    dbo.GetStudentStatus(m.Score) AS Status
FROM
    Student s
JOIN
    Marks m
ON
    s.Sid = m.Sid;

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



