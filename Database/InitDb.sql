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
		NOT NULL);
INSERT tb_User
	(Number,Password)
	VALUES
	('3240707001',HASHBYTES('MD5','7001'));