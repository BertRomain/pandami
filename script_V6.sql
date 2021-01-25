USE [bddPandami]
GO
ALTER TABLE [dbo].[member] DROP CONSTRAINT [FK_member_city]
GO
ALTER TABLE [dbo].[city] DROP CONSTRAINT [FK_city_zipCode]
GO
/****** Object:  Table [dbo].[zipCode]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[zipCode]') AND type in (N'U'))
DROP TABLE [dbo].[zipCode]
GO
/****** Object:  Table [dbo].[voluntaryCancelReason]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[voluntaryCancelReason]') AND type in (N'U'))
DROP TABLE [dbo].[voluntaryCancelReason]
GO
/****** Object:  Table [dbo].[serviceRequest]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serviceRequest]') AND type in (N'U'))
DROP TABLE [dbo].[serviceRequest]
GO
/****** Object:  Table [dbo].[serviceName]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serviceName]') AND type in (N'U'))
DROP TABLE [dbo].[serviceName]
GO
/****** Object:  Table [dbo].[serviceCategory]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[serviceCategory]') AND type in (N'U'))
DROP TABLE [dbo].[serviceCategory]
GO
/****** Object:  Table [dbo].[requestAnswer]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[requestAnswer]') AND type in (N'U'))
DROP TABLE [dbo].[requestAnswer]
GO
/****** Object:  Table [dbo].[member]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[member]') AND type in (N'U'))
DROP TABLE [dbo].[member]
GO
/****** Object:  Table [dbo].[historic]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[historic]') AND type in (N'U'))
DROP TABLE [dbo].[historic]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[comment]') AND type in (N'U'))
DROP TABLE [dbo].[comment]
GO
/****** Object:  Table [dbo].[city]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city]') AND type in (N'U'))
DROP TABLE [dbo].[city]
GO
/****** Object:  Table [dbo].[beneficiaryCancelReason]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[beneficiaryCancelReason]') AND type in (N'U'))
DROP TABLE [dbo].[beneficiaryCancelReason]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 22/01/2021 15:11:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[answer]') AND type in (N'U'))
DROP TABLE [dbo].[answer]
GO
USE [master]
GO
/****** Object:  Database [bddPandami]    Script Date: 22/01/2021 15:11:51 ******/
DROP DATABASE [bddPandami]
GO
/****** Object:  Database [bddPandami]    Script Date: 22/01/2021 15:11:51 ******/
CREATE DATABASE [bddPandami]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bddPandami', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bddPandami.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bddPandami_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bddPandami_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bddPandami] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bddPandami].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bddPandami] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bddPandami] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bddPandami] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bddPandami] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bddPandami] SET ARITHABORT OFF 
GO
ALTER DATABASE [bddPandami] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bddPandami] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bddPandami] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bddPandami] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bddPandami] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bddPandami] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bddPandami] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bddPandami] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bddPandami] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bddPandami] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bddPandami] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bddPandami] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bddPandami] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bddPandami] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bddPandami] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bddPandami] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bddPandami] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bddPandami] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bddPandami] SET  MULTI_USER 
GO
ALTER DATABASE [bddPandami] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bddPandami] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bddPandami] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bddPandami] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bddPandami] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bddPandami] SET QUERY_STORE = OFF
GO
USE [bddPandami]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answer](
	[answerID] [nvarchar](50) NOT NULL,
	[answer] [nvarchar](3) NULL,
 CONSTRAINT [PK_answer] PRIMARY KEY CLUSTERED 
(
	[answerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[beneficiaryCancelReason]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[beneficiaryCancelReason](
	[cancelReasonID] [nvarchar](50) NOT NULL,
	[reason] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_beneficiaryCancelReason] PRIMARY KEY CLUSTERED 
(
	[cancelReasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[city]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[cityID] [int] NOT NULL,
	[cityName] [nvarchar](50) NOT NULL,
	[cityZipcode] [int] NOT NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[comment] [nvarchar](200) NOT NULL,
	[rating] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historic]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historic](
	[historicID] [nvarchar](max) NOT NULL,
	[subscribeDate] [date] NOT NULL,
	[unsubscribeDate] [date] NOT NULL,
	[comment] [nvarchar](280) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member](
	[memberID] [varchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[birthdate] [date] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[phone] [int] NOT NULL,
	[address] [nvarchar](120) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[cityFK] [int] NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_member] PRIMARY KEY CLUSTERED 
(
	[memberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[requestAnswer]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requestAnswer](
	[refusalDate] [date] NULL,
	[acceptanceDate] [date] NULL,
	[cancelDate] [date] NULL,
	[answerDate] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serviceCategory]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serviceCategory](
	[serviceCategoryID] [nvarchar](50) NOT NULL,
	[serviceCategory] [nvarchar](50) NULL,
 CONSTRAINT [PK_serviceCategory] PRIMARY KEY CLUSTERED 
(
	[serviceCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serviceName]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serviceName](
	[serviceID] [nvarchar](max) NOT NULL,
	[serviceName] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serviceRequest]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serviceRequest](
	[serviceRequestID] [nvarchar](max) NOT NULL,
	[serviceDate] [date] NOT NULL,
	[serviceAddress] [nvarchar](120) NOT NULL,
	[priority] [bit] NULL,
	[creationDate] [date] NOT NULL,
	[cancelDate] [date] NULL,
	[startTime] [time](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[voluntaryCancelReason]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[voluntaryCancelReason](
	[voluntaryCancelReasonID] [nvarchar](max) NOT NULL,
	[CancelReason] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zipCode]    Script Date: 22/01/2021 15:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipCode](
	[zipCodeID] [int] NOT NULL,
	[zipCode] [int] NOT NULL,
 CONSTRAINT [PK_zipCode] PRIMARY KEY CLUSTERED 
(
	[zipCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[answer] ([answerID], [answer]) VALUES (N'No', N'Non')
INSERT [dbo].[answer] ([answerID], [answer]) VALUES (N'Yes', N'Oui')
GO
INSERT [dbo].[city] ([cityID], [cityName], [cityZipcode]) VALUES (1, N'Pantin', 1)
GO
INSERT [dbo].[member] ([memberID], [firstName], [lastName], [birthdate], [email], [phone], [address], [login], [cityFK], [password]) VALUES (N'123456', N'Jean-Jacques', N'Goldman', CAST(N'1952-12-12' AS Date), N'jjg@jjg.com', 625244475, N'11 rue de Unna', N'jjgthebest', 1, N'fuckbruel')
GO
INSERT [dbo].[zipCode] ([zipCodeID], [zipCode]) VALUES (1, 93500)
GO
ALTER TABLE [dbo].[city]  WITH CHECK ADD  CONSTRAINT [FK_city_zipCode] FOREIGN KEY([cityZipcode])
REFERENCES [dbo].[zipCode] ([zipCodeID])
GO
ALTER TABLE [dbo].[city] CHECK CONSTRAINT [FK_city_zipCode]
GO
ALTER TABLE [dbo].[member]  WITH CHECK ADD  CONSTRAINT [FK_member_city] FOREIGN KEY([cityFK])
REFERENCES [dbo].[city] ([cityID])
GO
ALTER TABLE [dbo].[member] CHECK CONSTRAINT [FK_member_city]
GO
USE [master]
GO
ALTER DATABASE [bddPandami] SET  READ_WRITE 
GO
