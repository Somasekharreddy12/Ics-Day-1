create database Assignments 
use assignments
create table EMP
(
  EMPNO int primary key,
  ENAME varchar(20),
  JOB varchar(20),
  MGR_Id int,
  HIREDATE DATE,
  SAL int,
  COMM int,
  DEPTNO int foreign key  REFERENCES DEPT(DEPTNO)
)

insert into EMP values
(7369,'SMITH','CLERK',7902,'17-DEC-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)
 
create table DEPT
(
DEPTNO INT PRIMARY KEY,
DNAME VARCHAR(20),
LOC VARCHAR(20)
)
 
insert into dept values
(10,'ACCOUNTING','NEW YORK'), 
(20,'RESEARCH','DALLAS') ,
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON')

select * from emp;
select * from dept;
--List all employees whose name begins with 'A'
select ename from emp
where ename like 'A%'
 
--Select all those employees who don't have a manager
select ename
from emp 
where mgr_id is null
 
--List employee name, number and salary for those employees who earn in the range 1200 to 1400
select ename,empno,sal
from emp 
where sal between (1200) and (1400)
 
--Give all the employees in the RESEARCH department a 10% pay rise. 
--Verify that this has been done by listing all their details before and after the rise.
select Sal,Sal+(0.10*sal) as pay_raise                
from Emp
where Deptno=(select Deptno from Dept where Dname='Research')
 
 
--Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) as Clerk_Count                 
from EMP
where job='Clerk'
 
--Find the average salary for each job type and the number of people employed in each job.
select job,avg(sal) as Avg_Salary ,count(*) as EMP_Count   
from EMP
Group by job;
 
--List the employees with the lowest and highest salary.
select Ename from emp                         
where Sal=(select max(Sal) from emp)
select ename from emp 
where sal=(select min(sal) from emp)
 
 
--List full details of departments that don't have any employees.
select *
from dept left join emp on dept.deptno = emp.deptno
where emp.deptno is null
 
 
--Get the names and salaries of all the analysts earning more than 1200 who are based in department 20.
--Sort the answer by ascending order of name. 
select ename,sal from emp                            
where job='Analyst' and sal>1200 and deptno=20
order by ename asc
 
--For each department, list its name and number together with the total salary paid to employees in that department. 
select e.Ename,e.Sal,e.Deptno,sum(e1.Sal) as Total_sal  
from emp e join emp e1
on e.Deptno=e1.Deptno
group by e.ename,e.sal,e.deptno
 
 
--Find out salary of both MILLER and SMITH.
select ename,sal
from emp
where ename in ('miller','smith')
 
 
--Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select ename from emp
where ename like 'A%' or ename like 'M%'
 
--Compute yearly salary of SMITH.
select sal,sal*12 as smith_yearly_salary
from emp
where ename='smith'
 
 
--List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
select ename,sal
from emp
where sal not between 1500 and 2850
 
--Find all managers who have more than 2 employees reporting to them
select mgr_id,count(*) as Employee_Count           
from emp group by mgr_id
having  count(*)>2

create or alter proc sp_get(@empid int)
as
begin
  select EmpNo,Ename,Sal,Sal+100 as 'Incremented Salary' from Emp where Sal<1250 and EmpNo=@empid
end

sp_Updatesal 7250