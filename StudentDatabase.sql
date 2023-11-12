SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE StudentDatabase;

-- Create the Student table.
IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[Student]')
AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Student]([StudentID] [int] IDENTITY(1,1) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[FirstName] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_School.Student] PRIMARY KEY CLUSTERED
(
[StudentID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]
END
GO


--Create the StudentGrade table.
IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[StudentGrade]')
AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentGrade]
([StudentGradeID] [int] NOT NULL,
[StudentID] [int] NOT NULL,
[AssignmentID] [int] NOT NULL,
[Grade_Achieved] [decimal](3, 2) NULL,
CONSTRAINT [PK_StudentGrade] PRIMARY KEY CLUSTERED
(
[StudentGradeID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]
END
GO

-- Create the Assignment table.
IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[Assignment]')
AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Assignment]
([AssignmentID] [int] NOT NULL,
[Name] [nvarchar](100) NOT NULL,
[MaxPoints] [nvarchar] (100) NOT NULL,
CONSTRAINT [PK_School.Assignment] PRIMARY KEY CLUSTERED
(
[AssignmentID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]
END
GO


--Defining relationships between tables

-- Define the relationship between StudentGrade and Assignment.
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys
--WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentGrade_Assignment]')
--AND parent_object_id = OBJECT_ID(N'[dbo].[StudentGrade]'))
--ALTER TABLE [dbo].[StudentGrade] WITH CHECK ADD
--CONSTRAINT [FK_StudentGrade_Assignment] FOREIGN KEY([AssignmentID])
--REFERENCES [dbo].[Assignment] ([AssignmentID])
--GO
--ALTER TABLE [dbo].[StudentGrade] CHECK
--CONSTRAINT [FK_StudentGrade_Assignment]
--GO


--INSERT INTO dbo.Assignment(AssignmentID, Name, MaxPoints)
--VALUES (1050, 'Chemistry', 4, 1);
