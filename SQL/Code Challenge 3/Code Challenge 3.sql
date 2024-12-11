use [SQL Code challenge ]


create table Coursedetails
(
  C_id varchar(30),
  C_name varchar(30),
  Startdate date,
  End_date date,
  Fee float
 
)
insert into Coursedetails values
('DN003','DotNet','2018-02-01','2018-02-28',15000),
('DV004','DataVisualization','2018-03-01','2018-04-15',15000),
('JA002','AdvancedJava','2018-01-02','2018-01-20',10000),
('JC001','CoreJava','2018-01-02','2018-01-12',3000);
 
select * from coursedetails

CREATE Function
CalculateCourseDuration(@StartDate DATE, @EndDate DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @StartDate, @EndDate);
END;
 
SELECT dbo.CalculateCourseDuration
('2018-03-01', '2018-04-15') 
AS
CourseDuration;

---------------------------------------------------------------------------------------------------------------------------------------

---2.creating a trigger which modifies in t_CourseInfo
CREATE TABLE T_CourseInfo
(
    CourseName VARCHAR(60),
    StartDate DATE
);

CREATE TRIGGER trg_InsertCourseInfo
ON Coursedetails
AFTER INSERT
AS
BEGIN
    -- Insert CourseName and StartDate into T_CourseInfo
    INSERT INTO T_CourseInfo (CourseName, StartDate)
    SELECT C_Name, Startdate
    FROM INSERTED;
END;
GO

--------Insert a new record into the Coursedetails table to test the trigger.
 
INSERT INTO Coursedetails (C_id, C_Name, Startdate, End_date, Fee)
VALUES ('CC004', 'Cloud computing', '2024-05-20', '2024-02-15', 15000);
 

 SELECT * FROM T_CourseInfo;
 ----------------------------------------------------------------------------------------------------
 CREATE PROCEDURE sp_InsertProductDetails
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @GeneratedProductId INT ,
    @DiscountedPrice DECIMAL(10, 2) 
AS
BEGIN
    DECLARE @MaxProductId INT;
    SELECT @MaxProductId = ISNULL(MAX(ProductId), 0) + 1 FROM ProductsDetails;

    SET @DiscountedPrice = @Price - (@Price * 0.10);

    INSERT INTO ProductsDetails (ProductId, ProductName, Price, DiscountedPrice)
    VALUES (@MaxProductId, @ProductName, @Price, @DiscountedPrice);

    SET @GeneratedProductId = @MaxProductId;
END;



