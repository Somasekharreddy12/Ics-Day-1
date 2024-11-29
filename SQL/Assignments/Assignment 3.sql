use Assignments
SELECT * FROM EMP 
---------------------------------------------------------1. Retrieve a list of MANAGERS.-------------------------------------------------------------------------------------------- 
select * from EMP WHERE JOB = 'MANAGER'
 ----------------------------Find out the names and salaries of all employees earning more than 1000 per month.---------------------------
 select * from EMP WHERE SAL > 1000
 -----------------------------------Display the names and salaries of all employees except JAMES.-----------------------------------
 select ENAME , SAL  from EMP WHERE ENAME !=  'JAMES'
 ----------------------------------------------Find out the details of employees whose names begin with ‘S’. ----------------------------------------------------------
 select * from EMP where ENAME  LIKE 'S%'
------------------------------------------------------- Find out the names of all employees that have ‘A’ anywhere in their name. --------------------------------------------------------
select * from EMP where ENAME LIKE '%A%'
-----------------------------Find out the names of all employees that have ‘L’ as their third character in their name. 
select * from EMP where ENAME LIKE '__L%'
----------------------------------------Compute daily salary of JONES. 
Select  ENAME , SAL%30  as Dailysalary  from EMP WHERE ENAME = 'JONES'
 --------------------------Calculate the total monthly salary of all employees.---------------------------------
 select SUM (SAL) AS TOTAL_SALARY  from EMP
 -----------------------------------------Print the average annual salary .---------------------------------------
 SELECT AVG (SAL*12) AS ANNUAL_SAL FROM EMP
----------------- Select the name, job, salary, department number of all employees except SALESMAN from department number 30. ----------------
SELECT ENAME , JOB , SAL , DEPTNO FROM EMP WHERE JOB != 'SALESMAN'
------------------------------List unique departments of the EMP table.-----------------------------------------
SELECT DISTINCT (DEPTNO) AS Unique_DEPT FROM EMP

-------------------------------------List the name and salary of employees who earn more than 1500 and are in department Label the columns Employee and Monthly Salary respectively.

select ename as Employee,sal as monthly_salary from emp where sal > 1500 and (deptno =10 or deptno = 30)
 
----------------------------------------------Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select ename,job,sal from emp where (job = 'analyst' or job = 'manager') and sal not in (1000,3000,5000)
 
---------------------------------------------Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 

select ename,sal,comm from emp where comm > sal*0.1
 
-----------------------------------------------Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 

select ename from emp where ename like '%ll%' and deptno = 30 or mgr_id = 7782
 
--------------------------------------------------Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 

select  ename ,count(ename) as number_of_employees  from emp where datediff(year,hiredate,getdate())  between 30 and 40 group by ename
 
---------------------------------------------------Retrieve the names of departments in ascending order and their employees in descending order. 

select d.dname,e.ename from emp e,dept d where e.deptno = d.deptno order by d.dname asc, e.ename desc
 
---------------------------------------------------Find out experience of MILLER. 

select datediff(year,hiredate,getdate()) as employee_Experience from emp  where ename = 'miller'
 
