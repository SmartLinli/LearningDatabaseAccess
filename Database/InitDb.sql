--�������ݿ⣻
USE master;
IF DB_ID('EduBase2024') IS NOT NULL
	BEGIN
		ALTER DATABASE EduBase2024
			SET SINGLE_USER
			WITH ROLLBACK IMMEDIATE;
		DROP DATABASE EduBase2024;
	END
GO
CREATE DATABASE EduBase2024
	ON
		(NAME='Datafile'
		,FILENAME='C:\EduBase2024\DataFile.mdf')
	LOG ON
		(NAME='Logfile'
		,FILENAME='C:\EduBase2024\Logfile.ldf');
GO
USE EduBase2024;
--������
----�û���
CREATE TABLE tb_User
	(Number
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,Password
		VARBINARY(128)
		NOT NULL
	,Role
		CHAR(1)
		NOT NULL
		DEFAULT('S'));
INSERT tb_User
	(Number,Password,Role)
	VALUES
	('3230707001',HASHBYTES('MD5','7001'),'S')	--ѧ��
	,('2004004',HASHBYTES('MD5','004'),'T')		--��ʦ
	,('001',HASHBYTES('MD5','001'),'P')		--У��
	,('20091009',HASHBYTES('MD5','009'),'C');		--����Ա
----Ժϵ��
CREATE TABLE tb_Department
	(Number
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT tb_Department
	(Number,Name)
	VALUES
	(1,'����ѧԺ')
	,(2,'��ҽѧԺ');
----רҵ��
CREATE TABLE tb_Major
	(Number
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,DepartmentNumber
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Department(Number));
INSERT tb_Major
	(Number,Name,DepartmentNumber)
	VALUES
	(1,'����',1)
	,(2,'�Ź�',1)
	,(3,'����',1)
	,(4,'��ҽ',2)
	,(5,'�ٴ�',2);
----�༶��
CREATE TABLE tb_Class
	(Number
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,MajorNumber
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Major(Number))
INSERT tb_Class
	(Number,Name,MajorNumber)
	VALUES
	(1,'23����1',1)
	,(2,'23����2',1)
	,(3,'23�Ź�',2)
	,(4,'23����',3)
	,(5,'23��ҽ',4)
	,(6,'23�ٴ�',5);
----ѧ����
CREATE TABLE tb_Student
	(Number
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,Gender
		BIT
		NOT NULL
	,BirthDate
		DATE
		NOT NULL
	,ClassNumber
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Class(Number)
	,Speciality
		VARCHAR(100)
		NULL
	,Photo
		VARBINARY(MAX)
		NULL);
INSERT tb_Student
	(Number,Name,Gender,BirthDate,ClassNumber,Speciality)
	VALUES
	('3230707001','������',1,'2005-06-08',3,'˯��')
	,('3230707002','���ҵ',1,'2004/9/2',3,'����')
	,('3230707004','����',0,'2005/6/28',3,'������')
	,('3230707005','��˼��',0,'2002-11-12',3,NULL)
	,('3230708001','л���',0,'2005/2/10',1,NULL)
	,('3230708002','��껿�',1,'2004/11/1',1,NULL)
	,('3230708003','���',0,'2005/7/16',1,NULL)
	,('3230708005','��С��',0,'2004/9/11',1,NULL)
	,('3230708076','����Ң',1,'2005/4/21',2,NULL)
	,('3230708077','��˼��',0,'2005/3/9',2,NULL)
	,('3230708078','������',1,'2005/2/19',2,NULL)
	,('3230708079','�¼η�',0,'2004/9/8',2,NULL);
GO
----�γ̱�
CREATE TABLE tb_Course
	(No
		CHAR(4)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(50)
		NOT NULL
	,Pinyin
		VARCHAR(50)
		NULL
	,PreCourseNo
		CHAR(4)
		NULL
	,Credit
		DECIMAL(3,1)
		NOT NULL
		DEFAULT(3.0)
	,StudyType
		VARCHAR(20)
		NOT NULL
	,ExamType
		VARCHAR(10)
		NOT NULL);
----��������γ̱�
BULK INSERT tb_Course
	FROM 'C:\Course.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
--���ݿⰲȫ��
----����SQL Server��֤�ĵ�¼��
USE master;
IF SUSER_ID('SqlLogin1') IS NOT NULL		
	DROP LOGIN SqlLogin1;	
GO		
CREATE LOGIN SqlLogin1 		
	WITH 	
		PASSWORD='$q17o9!n1' 
GO
----��EduBase2024�д����û�
USE EduBase2024;
DROP USER IF EXISTS DbUser1;				
GO				
CREATE USER DbUser1 				
	FOR LOGIN SqlLogin1;			
GO
----�������ݿ��ɫ
EXEC sys.sp_addrolemember 'db_datareader','DbUser1';
EXEC sys.sp_addrolemember 'db_datawriter','DbUser1';
