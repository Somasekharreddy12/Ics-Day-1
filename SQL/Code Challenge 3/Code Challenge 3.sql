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
 drop table ProductDetails
 
 
 create table ProductDetails(
ProductId int,
ProductName varchar(20),
Price float(10),
DiscountedPrice float(10))

 CREATE or alter PROCEDURE sp_Insert_ProductDetails 
    @ProductName VARCHAR(20),
    @Price int,
    @GeneratedProductId INT OUTPUT ,
    @DiscountedPrice int OUTPUT
AS
BEGIN

    DECLARE @MaxProductId INT;
    SELECT @MaxProductId = ISNULL(MAX(ProductId), 0) + 1
	FROM ProductDetails;
	--Set @ProductName = cookies
    SET @DiscountedPrice = @Price - (@Price * 0.10);

    INSERT INTO ProductDetails (ProductId, ProductName, Price, DiscountedPrice)
    VALUES (@MaxProductId, @ProductName, @Price, @DiscountedPrice);

    SET @GeneratedProductId = @MaxProductId;
END;

select * from ProductDetails



declare @pid INT , @dprice INT
execute sp_Insert_ProductDetails 'cookies', 2000, @pid output ,@dprice output




