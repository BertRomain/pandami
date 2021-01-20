USE [bddEQL]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'clientregion'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'clientregion'
GO
/****** Object:  StoredProcedure [dbo].[GetClientAndRegion]    Script Date: 18/01/2021 09:52:01 ******/
DROP PROCEDURE [dbo].[GetClientAndRegion]
GO
/****** Object:  Table [dbo].[TelephoneSet]    Script Date: 18/01/2021 09:52:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TelephoneSet]') AND type in (N'U'))
DROP TABLE [dbo].[TelephoneSet]
GO
/****** Object:  View [dbo].[clientregion]    Script Date: 18/01/2021 09:52:01 ******/
DROP VIEW [dbo].[clientregion]
GO
/****** Object:  Table [dbo].[region]    Script Date: 18/01/2021 09:52:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[region]') AND type in (N'U'))
DROP TABLE [dbo].[region]
GO
/****** Object:  Table [dbo].[client]    Script Date: 18/01/2021 09:52:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[client]') AND type in (N'U'))
DROP TABLE [dbo].[client]
GO
USE [master]
GO
/****** Object:  Database [bddEQL]    Script Date: 18/01/2021 09:52:01 ******/
DROP DATABASE [bddEQL]
GO
/****** Object:  Database [bddEQL]    Script Date: 18/01/2021 09:52:01 ******/
CREATE DATABASE [bddEQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bddEQL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bddEQL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bddEQL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bddEQL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bddEQL] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bddEQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bddEQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bddEQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bddEQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bddEQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bddEQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [bddEQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bddEQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bddEQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bddEQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bddEQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bddEQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bddEQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bddEQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bddEQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bddEQL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bddEQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bddEQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bddEQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bddEQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bddEQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bddEQL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bddEQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bddEQL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bddEQL] SET  MULTI_USER 
GO
ALTER DATABASE [bddEQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bddEQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bddEQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bddEQL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bddEQL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bddEQL] SET QUERY_STORE = OFF
GO
USE [bddEQL]
GO
/****** Object:  Table [dbo].[client]    Script Date: 18/01/2021 09:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[noclient] [int] NOT NULL,
	[nom] [nvarchar](50) NULL,
	[adresse] [nvarchar](50) NULL,
	[noregion] [int] NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[noclient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[region]    Script Date: 18/01/2021 09:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[region](
	[idregion] [int] NOT NULL,
	[nomregion] [nvarchar](50) NULL,
 CONSTRAINT [PK_region] PRIMARY KEY CLUSTERED 
(
	[idregion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[clientregion]    Script Date: 18/01/2021 09:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[clientregion]
AS
SELECT dbo.client.noclient, dbo.client.nom, dbo.client.adresse, dbo.region.nomregion
FROM     dbo.client INNER JOIN
                  dbo.region ON dbo.client.noregion = dbo.region.idregion
GO
/****** Object:  Table [dbo].[TelephoneSet]    Script Date: 18/01/2021 09:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelephoneSet](
	[IdTelephone] [int] NOT NULL,
	[NumeroTel] [nvarchar](max) NOT NULL,
	[TypeNumero] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TelephoneSet] PRIMARY KEY CLUSTERED 
(
	[IdTelephone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[client] ([noclient], [nom], [adresse], [noregion]) VALUES (1, N'Dupuy', N'1 rue d''ici', 2)
GO
INSERT [dbo].[client] ([noclient], [nom], [adresse], [noregion]) VALUES (2, N'Paul', N'12 avenue d''ailleurs', 1)
GO
INSERT [dbo].[client] ([noclient], [nom], [adresse], [noregion]) VALUES (10, N'Zidane', N'la maison de Zizou', 2)
GO
INSERT [dbo].[client] ([noclient], [nom], [adresse], [noregion]) VALUES (20, N'EQL', N'Paris', 75)
GO
INSERT [dbo].[client] ([noclient], [nom], [adresse], [noregion]) VALUES (21, N'Patrick', N'Bordeaux', 33)
GO
INSERT [dbo].[region] ([idregion], [nomregion]) VALUES (1, N'Ain')
GO
INSERT [dbo].[region] ([idregion], [nomregion]) VALUES (2, N'Aisne')
GO
INSERT [dbo].[region] ([idregion], [nomregion]) VALUES (3, N'Aveyron')
GO
/****** Object:  StoredProcedure [dbo].[GetClientAndRegion]    Script Date: 18/01/2021 09:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetClientAndRegion]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT client.nom, client.adresse, region.nomregion
	  FROM client
	  INNER JOIN region ON region.idregion = client.noregion;

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "client"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "region"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'clientregion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'clientregion'
GO
USE [master]
GO
ALTER DATABASE [bddEQL] SET  READ_WRITE 
GO
