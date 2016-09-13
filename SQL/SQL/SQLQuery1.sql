Create table LoginInfo(
username varchar(50),
password varchar(50),
operatorname varchar(max),
role varchar(10),
Active varchar(10)
primary key(username))
insert into LoginInfo values('Admin','Admin','Enosh','Admin','Active')
insert into LoginInfo values('MNGR001','123','Enosh','Manager','Active')
insert into LoginInfo values('B001/S001','123','Enosh','Student','Inactive')
select * from logininfo

Create table StudentInfo(
SID varchar(50),
FirstName varchar(50),
Lastname varchar(50),
FullName varchar(max),
NamewithInetials varchar(max),
Gender varchar(50),
DateOfBirth DateTime,
NIC varchar(10),
Course varchar(50),
batch varchar(50),
joindate datetime,
contactno varchar(50),
emailaddress varchar(50),
username varchar(50),
usercreateddate datetime,
operatorUN varchar(50),
primary key (username))
insert into StudentInfo values('S001','Lakshan','Enosh','Batagoda Arachchige Lakshan Enosh','B.A. Lakshan Enosh','Male','1994-12-26','943613192v'
,'CID001','B001','2015-01-08','0770539393','enosh.94@hotmail.com','B001/S001','2016-03-06','MNGR001')
select * from StudentInfo

Create table Course(
courseID varchar(50),
CourseName varchar(max),
createdby varchar(50)
primary key(CourseID))
insert into course values('CID001','HND COMPUTER','MNGR001')
insert into course values('CID002','HND Marketing','MNGR001')

select * from Course

Create table batch(
BatchID varchar(50),
CourseID varchar(50),
creadedby varchar(50)
primary key (BatchID))
insert into batch values('B001','CID001','MNGR001')
insert into batch values('B002','CID002','MNGR001')
select*from batch

create table subject(
SubjectID varchar(50),
SubjectName Varchar(max),
CourseID varchar(50),
operator varchar(50)
primary key(subjectid))
insert into subject values('SUB001','Computer Systems','CID001','MNGR001')
select * from subject

Create table assignment(
AssignmentID varchar(50),
Assignmetname varchar(max),
CourseID varchar(50),
CourseName varchar(max),
BatchID varchar(50),
SubjectID varchar(50),
SubjectName Varchar(max),
Issueddate datetime,
Submissiondate datetime,
Operator varchar(50),
AssignmentPas varchar(max)
primary key(AssignmentID))

insert into assignment values('ASGN001','','','','B001','','','','','MNGR001','')
insert into assignment values('ASGN002','ASGN002','CID001','HND In COMPUTER','B001','SUB001','Computer Systems','2016-03-01 00:00:00.000','2016-03-02 00:00:00.000','MNGR001','')
select * from assignment
drop table assignment
delete from assignment where assignmentID='ASGN001'
select * from assignment where BatchID='B001'

Create table uploadedassignmentdetails(
SID varchar(50),
AssignmentID varchar(50),
Assignmetname varchar(max),
CourseName varchar(max),
BatchID varchar(50),
SubjectID varchar(50),
SubjectName Varchar(max),
Submissiondate datetime,
SubmitedDate datetime,
primary key(AssignmentID,SID))
select * from uploadedassignmentdetails
drop table uploadedassignmentdetails
delete from uploadedassignmentdetails where SID='S002'

Create table AssignmentResult(
SID varchar(50),
SubjectName Varchar(max),
BatchID varchar(50),
Result varchar(50))
