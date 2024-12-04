use Assignments

SELECT * FROM EMP



DECLARE @dateofbirth 
DATE = '2001-09-03';  
     SELECT datename(weekday, @dateofbirth)
AS dayofweek;

-------------------------------------------------------------------------------------------------------------------------------------------

DECLARE @Birthday DATE = '2001-09-03';
SELECT DATEDIFF(DAY, @Birthday, GETDATE()) 
AS AgeInDays;

---------------------------------------------------------------------------------------------------------------------

SELECT * FROM EMP
WHERE
HireDate < DATEADD(YEAR, -5, GETDATE())AND MONTH(HireDate) = MONTH(GETDATE());

---------------------------------------------------------------------------------------------------------------------------


 
CREATE TABLE Employee 
(
    EmpNo INT PRIMARY KEY,
    EName NVARCHAR(50),
    Sal FLOAT,
    DOJ DATE
);

Begin transaction

INSERT INTO Employee (EmpNo, EName, Sal, DOJ)
VALUES
    (1, 'Jones', 8000, '1994-01-06'),
    (2, 'martin', 6000, '2001-05-05'),
    (3, 'blake', 3000, '1998-08-03');


      UPDATE Employee
SET Sal = Sal * 1.15
WHERE EmpNo = 2;
SELECT * FROM Employee

DELETE FROM Employee
WHERE EmpNo = 1;

rollback
commit


SELECT * FROM Employee

 
------------------------------------------------------------------------------------------------------------------------------

create Function Calculate_Bonus                 
(
  @deptno int,
  @sal decimal(18,2)
  )
  returns decimal(18,2)
  as 
  begin
  declare @Bonus float;
  if  @deptno=10
     set  @bonus=@sal*0.15;
  else if @deptno=20
     set @bonus=@sal*0.20;
  else
       set @bonus=@sal*0.05;
  return @bonus;
  end;
 
     select empno, ename,dbo.Calculate_Bonus(deptno,sal) as BONUS from emp     

-----------------------------------------------------------------------------------------------------------------------

create procedure  Sal_update_in_Sales_dept           
  as
  begin
    update emp
    set sal=sal+500
	where deptno=(select deptno from dept where dname='SALES') and sal<1500
  end
 
  Exec Sal_update_in_Sales_dept
  select *from EMP
 