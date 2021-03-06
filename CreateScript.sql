USE [bddPandami]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[beneficiaryCancelReason]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[city]    Script Date: 22/01/2021 10:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[cityID] [int] NOT NULL,
	[zipCodeFK] [int] NULL,
	[cityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 22/01/2021 10:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[comment] [nvarchar](200) NOT NULL,
	[rating] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historic]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[member]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[requestAnswer]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[serviceCategory]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[serviceName]    Script Date: 22/01/2021 10:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serviceName](
	[serviceID] [nvarchar](max) NOT NULL,
	[serviceName] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serviceRequest]    Script Date: 22/01/2021 10:58:27 ******/
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
/****** Object:  Table [dbo].[voluntaryCancelReason]    Script Date: 22/01/2021 10:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[voluntaryCancelReason](
	[voluntaryCancelReasonID] [nvarchar](max) NOT NULL,
	[CancelReason] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zipCode]    Script Date: 22/01/2021 10:58:27 ******/
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
INSERT [dbo].[city] ([cityID], [zipCodeFK], [cityName]) VALUES (95380, NULL, N'Louvres')
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
