CREATE TABLE books
(
    id INT Primary key,
    title VARCHAR(50),
    author VARCHAR(80),
    isbn VARCHAR(20) Unique,
    published_date DATETIME,
)
INSERT INTO books (id, title, author, isbn, published_date) VALUES
(1,'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2,'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3,'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');

Select *From books
Where author LIKE '%er';

create table Reviews
(
id int references books (Id),
book_id int,
reviewer_name varchar(40),
content varchar(40),
rating int,
published_date date,
)
insert into reviews values
(1,1,'John Smith','My first review',4,'2017-12-10'),
(2,2,'John Smith','My second review',5,'2017-10-13'),
(3,2,'Alice Walker','Another review',1,'2017-10-22')
 
 -----2.displaying title ,author,reviewer name----------------

select b.title,b.author,r.reviewer_name            
from books b join reviews r
on  b.id=r.book_id
 
 --------3.reviewe name who reviewed more than one book---------------

 select reviewer_name from Reviews               
where book_id is not null
group by reviewer_name
having count(distinct book_id)>1
---------- Employee  program ----------------------------------------
create table Employee
(
Id int,
Ename varchar(20),
Age int,
Addres varchar(20),
Salary int
)

 
insert into Employee values  
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

--------------Names of the Employee in lower case, whose salary is null------------


select lower(Ename) as Employee_name
from employee
where salary is null
---------------------------------------------------------------------------
 create table Emp_Name
(
Id int not null,
Ename varchar(20) not null,
Age int not null,
Addres varchar(20) not null,
Salary int
)

 
insert into Emp_Name values  
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP', 4500),
(7,'Muffy',24,'Indore',10000)


select Ename from Employee                            
where addres like'%o%'



 
------------Customers and Orders Table----------------------

create table CUSTOMERS (
    ID int primary key,
    NAME varchar(20),
    AGE int,
    ADDRESS varchar(30),
    SALARY float
);
 
insert into CUSTOMERS VALUES
(1,'Ramesh', 32, 'Ahmedabad', 2000.00),
(2,'Khilan', 25, 'Delhi', 1500.00),
(3,'Kaushik', 23, 'Kota', 2000.00),
(4,'Chaitali', 25, 'Mumbai', 6500.00),
(5,'Hardik', 27, 'Bhopal', 8500.00),
(6,'Komal', 22, 'MP', 4500.00),
(7,'Muffy', 24, 'Indore', 10000.00);


---------------------------------------------------------------------------------------------
create table Student_details                     
(
Register_no int primary key,
Name varchar(30) not null,
Age int not null,
Qualification varchar(20),
Mobile_no float not null,
Mail_id varchar(30),
locationn varchar(30),
Gender varchar(1)
)

 
create table Studentdetails                     
(
Register_no int primary key,
Name varchar(30) not null,
Age int not null,
Qualification varchar(20),
Mobile_no float not null,
Mail_id varchar(30),
locationn varchar(30),
Gender varchar(1)
)

 
insert into Student_details values                    
(2,'Sai',22,'B.E',9952836779,'sai@gmail,com','Chennai','M'),
(3,'Kumar',20,'BSC',7252836779,'kumar@gmail,com','Madurai','M'),
(4,'Selvi',22,'B.TECH',8952836779,'selvi@gmail,com','Selam','F'),
(5,'Nisha',25,'M.E',6352836779,'nisha@gmail,com','Theni','F'),
(6,'SaiSaran',21,'B.A',9865836779,'saisaran@gmail,com','Madurai','F'),
(7,'Tom',23,'BCA',6552836779,'tom@gmail,com','Pune','M')
 
 
select gender,count(*) as Total_count  
from Student_details
group by gender