-- **************************  DATABASE  **************************
-- Create Database

CREATE DATABASE [Challenge]

USE [Challenge]
GO

--  >>>>>>>> TABLES <<<<<<<<

-- Table Person

IF OBJECT_ID('Person') IS NOT NULL
	BEGIN
		DROP TABLE [Person]
	END

CREATE TABLE [Person]( [Id_Person] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
						[Id] INT NOT NULL,
						[FirstName] VARCHAR(40) NOT NULL,
						[LastName] VARCHAR(40) NOT NULL,
						[Mail] VARCHAR(40) NOT NULL,
						[Phone] INT NOT NULL)
GO

-- Table Admin

IF OBJECT_ID('Admin') IS NOT NULL
	BEGIN
		DROP TABLE [Admin]
	END

CREATE TABLE [Admin]( [Id_Admin] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
					  [Id_Person] INT NOT NULL, 
					  [Id_User] INT NOT NULL)
GO

--Table Student

IF OBJECT_ID('Student') IS NOT NULL
	BEGIN
		DROP TABLE [Student]
	END

CREATE TABLE [Student]( [Id_Student] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
						[Id_User] INT NOT NULL,
						[Id_Person] INT NOT NULL,
						[File_Number] INT NOT NULL)
GO

-- Table Profesor

IF OBJECT_ID('Profesor') IS NOT NULL
	BEGIN
		DROP TABLE [Profesor]
	END

CREATE TABLE [Profesor]( [Id_Profesor] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
						 [Id_Person] INT NOT NULL,
						 [State] INT NOT NULL)
GO

-- Table User

IF OBJECT_ID('User') IS NOT NULL
	BEGIN
		DROP TABLE [User]
	END

CREATE TABLE [User]( [Id_User] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
					 [User_Name] VARCHAR(50) NOT NULL,
					 [Pass] VARCHAR(50) NOT NULL)
GO

-- Table Subject

IF OBJECT_ID('Subject') IS NOT NULL
	BEGIN
		DROP TABLE [Subject]
	END

CREATE TABLE [Subject]( [Id_Subject] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
						[Name] VARCHAR(40) NOT NULL,
						[Description] VARCHAR (250) NOT NULL,
						[Capacity] INT NOT NULL,
						[Availability] INT NOT NULL,
						[TimeTable] VARCHAR(100) NOT NULL)
GO

-- Table Subject_Profesor

IF OBJECT_ID('Subject_Profesor') IS NOT NULL
	BEGIN
		DROP TABLE [Subject_Profesor]
	END

CREATE TABLE [Subject_Profesor]([Id_SubjProf] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
								[Id_Profesor] INT NOT NULL,
								[Id_Subject] INT NOT NULL)
GO

-- Table Subject_Student

IF OBJECT_ID('Subject_Student') IS NOT NULL
	BEGIN
		DROP TABLE [Subject_Student]
	END

CREATE TABLE [Subject_Student]([Id_SubjStud] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
								[Id_Student] INT NOT NULL,
								[Id_Subject] INT NOT NULL)
GO

-- >>>>>>>> RELATIONS <<<<<<<<


--Relation Person, Admin, User

IF OBJECT_ID('Admin') IS NOT NULL
	BEGIN
		ALTER TABLE [Admin]
		ADD CONSTRAINT [Id_Person] FOREIGN KEY([Id_Person]) REFERENCES [Person],
		CONSTRAINT [Id_User] FOREIGN KEY([Id_User]) REFERENCES [User]
	END	
GO

-- Relation Person, Student, User

IF OBJECT_ID('Student') IS NOT NULL
	BEGIN
		ALTER TABLE [Student]
		ADD CONSTRAINT [Id_UserS] FOREIGN KEY(Id_User) REFERENCES [User],
		CONSTRAINT [Id_PersonS] FOREIGN KEY(Id_Person) REFERENCES [Person]		
	END
GO

--Relation Person Profesor

IF OBJECT_ID('Profesor') IS NOT NULL
	BEGIN
		ALTER TABLE[Profesor]
		ADD CONSTRAINT [Id_PersonP] FOREIGN KEY([Id_Person]) REFERENCES [Person]
	END
GO

--Relation Subject_Profesor, Subject, Profesor

IF OBJECT_ID('Subject_Profesor') IS NOT NULL
	BEGIN
		ALTER TABLE [Subject_Profesor]
		ADD CONSTRAINT [Id_Subject] FOREIGN KEY ([Id_Subject]) REFERENCES [Subject],
		CONSTRAINT [Id_Profesor] FOREIGN KEY ([Id_Profesor]) REFERENCES [Profesor]
	END
GO

--Relation Subject_Student, Subject, Student

IF OBJECT_ID('Subject_Student') IS NOT NULL
	BEGIN
		ALTER TABLE [Subject_Student]
		ADD CONSTRAINT [Fk_Id_Subject] FOREIGN KEY ([Id_Subject]) REFERENCES [Subject],
		CONSTRAINT [Fk_Id_Student] FOREIGN KEY ([Id_Student]) REFERENCES [Student]
	END
GO

-- >>>>>>>>>> Data Entry <<<<<<<<<<

-- Persons

INSERT INTO [Person] VALUES ('23348348','Diaz','Pedro','pedrodiaz@mail.com','44457789'),
							('33445511','Puan','Ana','anapuan@mail.com','46677894'),
							('35777888','Rios','Micaela','micaelarios@mail.com','44889999'),
							('38123456','Paz','Juan','juanpaz@mail.com','48484554'),
                            ('22454545','Sanchez','Marta','martasanchez@mail.com','44434455'),
							('18235623','Mert','Carlos','carlosmert@mail.com','47568899'),
							('33441122','Garcia','Azul','azulgarcia@mail.com','43378998')
GO
-- Users

INSERT INTO [User] VALUES ('DiazP','DP2334'),
						  ('AnaP','AP3344'),
						  ('MicaR','3577MR'),
						  ('JuanPaz','3812JP'),
						  ('MartaS','MS2245'),
						  ('MertCarlos','AP1823'),
						  ('AzulG','3344AG')
GO

-- Admin

INSERT INTO [Admin] VALUES ('1','1')
GO

-- Students

INSERT INTO [Student] VALUES ('2','2','33445511'),
							 ('3','3','35777888'),
							 ('5','5','22454545'),
							 ('7','7','33441122')
GO

-- Profesors

INSERT INTO [Profesor] VALUES ('4','1'),
							  ('6','1')
GO

-- Subjects 

INSERT INTO [Subject] VALUES ('Análisis Matemático','El análisis matemático es una rama de las matemáticas​ que estudia los conjuntos numéricos tanto del punto de vista algebraico como topológico, así como las funciones entre esos conjuntos y construcciones derivadas.','30','0','Lunes de 15:00 a 18:00 Hs, Viernes de 18:00 a 21:00 Hs'),
                             ('Informática','Rama de la ciencia que se encarga de estudiar la administración de métodos, técnicas y procesos con el fin de almacenar, procesar y transmitir información y datos en formato digital.','30','0','Martes de 17:00 a 20:00 Hs, Jueves de 10:00 a 13:00 Hs'),
							 ('Ingles','Se estudiaran los tiempos verbales Simple Present, Simple Past, Present Continuous & Countable and Uncountable Nouns','30','0','Lunes de 09:00 a 12:00 Hs')
GO




