Technologies used(I have worked on the below technologies in the past hence the preference and comfort working on sample projects using these technologies):

UI: Mvc/CSS(MVC UI requesting Web API) + Swagger(For Web API)
Services: Web API(Have installed components using Nuget)
Database: SQL server Management Studio 2017
ORM: EF Db first 	

SQL Table script:

USE [Test]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],

 CONSTRAINT [UQ_Company_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],

 CONSTRAINT [UQ_Company_Phone] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


SUMMARY:

The solution provided displays ALL duplicate company records, duplicated by company name & sorted based on alphabetical descending order. You can choose to edit each record to resolve conflicts or delete it.

In addition, you can create new records which doesn't allow duplicate emails and phone numbers. Email-ids and phone numbers are required fields and have some basic validations using regex. 

I have created a Web API project and an MVC project under one solution. MVC project consumes the Web API project to perform Create/Delete/Update/Display operations. When you run the solution, both the projects start at the same time. I have added Swagger to the Web API project so you can see the different test inputs for API calls. In addition, you can use the MVC UI to perform CRUD operations. All operations work as expected.

If time permitted, I would have preferred working/improving on exception handling. While I have added some basic ones, adding some more would have completed all requirements.

I have tried maintaining clean code as much as possible. Also, I have separated all logical groups in separate classes.