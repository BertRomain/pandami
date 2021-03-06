USE [bddPandami]
GO
ALTER TABLE [dbo].[city] DROP CONSTRAINT [FK_city_zipCode]
GO
/****** Object:  Table [dbo].[zipCode]    Script Date: 25/01/2021 14:26:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[zipCode]') AND type in (N'U'))
DROP TABLE [dbo].[zipCode]
GO
/****** Object:  Table [dbo].[city]    Script Date: 25/01/2021 14:26:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city]') AND type in (N'U'))
DROP TABLE [dbo].[city]
GO
/****** Object:  Table [dbo].[city]    Script Date: 25/01/2021 14:26:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[cityID] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [nvarchar](50) NOT NULL,
	[zipCodeFK] [int] NOT NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zipCode]    Script Date: 25/01/2021 14:26:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipCode](
	[zipCodeID] [int] IDENTITY(1,1) NOT NULL,
	[zipCode] [int] NOT NULL,
 CONSTRAINT [PK_zipCode] PRIMARY KEY CLUSTERED 
(
	[zipCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([cityID], [cityName], [zipCodeFK]) VALUES (1, N'Pantin', 1)
INSERT [dbo].[city] ([cityID], [cityName], [zipCodeFK]) VALUES (3, N'Paris', 2)
INSERT [dbo].[city] ([cityID], [cityName], [zipCodeFK]) VALUES (4, N'Bordeaux', 3)
SET IDENTITY_INSERT [dbo].[city] OFF
GO
SET IDENTITY_INSERT [dbo].[zipCode] ON 

INSERT [dbo].[zipCode] ([zipCodeID], [zipCode]) VALUES (1, 93500)
INSERT [dbo].[zipCode] ([zipCodeID], [zipCode]) VALUES (2, 75000)
INSERT [dbo].[zipCode] ([zipCodeID], [zipCode]) VALUES (3, 33000)
SET IDENTITY_INSERT [dbo].[zipCode] OFF
GO
ALTER TABLE [dbo].[city]  WITH CHECK ADD  CONSTRAINT [FK_city_zipCode] FOREIGN KEY([zipCodeFK])
REFERENCES [dbo].[zipCode] ([zipCodeID])
GO
ALTER TABLE [dbo].[city] CHECK CONSTRAINT [FK_city_zipCode]
GO
