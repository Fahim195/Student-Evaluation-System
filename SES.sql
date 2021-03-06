USE [master]
GO
/****** Object:  Database [StudentEvaluationSystem]    Script Date: 08/27/2017 15:28:04 ******/
CREATE DATABASE [StudentEvaluationSystem] ON  PRIMARY 
( NAME = N'StudentEvaluationSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\StudentEvaluationSystem.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentEvaluationSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\StudentEvaluationSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentEvaluationSystem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentEvaluationSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentEvaluationSystem] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET ANSI_NULLS OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET ANSI_PADDING OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET ARITHABORT OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [StudentEvaluationSystem] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [StudentEvaluationSystem] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [StudentEvaluationSystem] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET  DISABLE_BROKER
GO
ALTER DATABASE [StudentEvaluationSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [StudentEvaluationSystem] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [StudentEvaluationSystem] SET  READ_WRITE
GO
ALTER DATABASE [StudentEvaluationSystem] SET RECOVERY SIMPLE
GO
ALTER DATABASE [StudentEvaluationSystem] SET  MULTI_USER
GO
ALTER DATABASE [StudentEvaluationSystem] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [StudentEvaluationSystem] SET DB_CHAINING OFF
GO
USE [StudentEvaluationSystem]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 08/27/2017 15:28:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [varchar](10) NOT NULL,
	[CourseDetails] [varchar](50) NOT NULL,
	[Section] [varchar](50) NULL,
	[Semister] [varchar](50) NULL,
	[Details] [varchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([ID], [CourseID], [CourseDetails], [Section], [Semister], [Details]) VALUES (1, N'CSE-131', N'Computer Fundamentals', N'PC-F', N'L3T1', N'CSE-131 PC-F L3T1')
INSERT [dbo].[Course] ([ID], [CourseID], [CourseDetails], [Section], [Semister], [Details]) VALUES (4, N'CSE-311', N'fdsafsdf', N'PC-G', N'L2T1', N'CSE-311 PC-G L2T1')
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  Table [dbo].[Teacher_Information]    Script Date: 08/27/2017 15:28:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher_Information](
	[TeacherID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 08/27/2017 15:28:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[CID] [int] NOT NULL,
	[StudentID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Attendance] [float] NULL,
	[Presentation] [float] NULL,
	[Assignment] [float] NULL,
	[Quiz1] [float] NULL,
	[Quiz2] [float] NULL,
	[Quiz3] [float] NULL,
	[QUIZ] [float] NULL,
	[Midterm] [float] NULL,
	[Final] [float] NULL,
	[TotalMarks] [float] NULL,
	[EvaluationGrade] [varchar](50) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON
INSERT [dbo].[Students] ([SID], [CID], [StudentID], [Name], [Attendance], [Presentation], [Assignment], [Quiz1], [Quiz2], [Quiz3], [QUIZ], [Midterm], [Final], [TotalMarks], [EvaluationGrade]) VALUES (1, 1, N'151-15-473', N'Kishor Lashkar', 6, 5, 6, 12, 12, 12, 12, 17, 30, 76, N'A')
SET IDENTITY_INSERT [dbo].[Students] OFF
/****** Object:  ForeignKey [FK_Students_Course]    Script Date: 08/27/2017 15:28:05 ******/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Course] FOREIGN KEY([CID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Course]
GO
