USE [master]
GO
/****** Object:  Database [CelebrityBirthday]    Script Date: 06/06/2019 14:38:23 ******/
CREATE DATABASE [CelebrityBirthday]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CelebrityBirthday', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CelebrityBirthday.mdf' , SIZE = 17408KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CelebrityBirthday_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CelebrityBirthday_log.ldf' , SIZE = 5696KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CelebrityBirthday] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CelebrityBirthday].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CelebrityBirthday] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET ARITHABORT OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CelebrityBirthday] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CelebrityBirthday] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CelebrityBirthday] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CelebrityBirthday] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CelebrityBirthday] SET  MULTI_USER 
GO
ALTER DATABASE [CelebrityBirthday] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CelebrityBirthday] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CelebrityBirthday] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CelebrityBirthday] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CelebrityBirthday] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CelebrityBirthday]
GO
/****** Object:  Table [dbo].[Dates]    Script Date: 06/06/2019 14:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dates](
	[bday] [numeric](2, 0) NOT NULL,
	[bmonth] [numeric](2, 0) NOT NULL,
	[uploadyear] [nchar](4) NULL,
	[uploadmonth] [nchar](2) NULL,
	[amended] [bit] NULL,
	[uploadday] [nchar](2) NULL,
 CONSTRAINT [PK_Dates] PRIMARY KEY CLUSTERED 
(
	[bday] ASC,
	[bmonth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] NOT NULL,
	[imgfilename] [nvarchar](100) NOT NULL,
	[imgfiletype] [nvarchar](5) NULL,
	[imgloadyr] [nchar](4) NULL,
	[imgloadmonth] [nchar](2) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forename] [nvarchar](50) NULL,
	[surname] [nvarchar](50) NOT NULL,
	[birthyear] [int] NOT NULL,
	[birthmonth] [int] NOT NULL,
	[birthday] [int] NOT NULL,
	[deathyear] [int] NOT NULL,
	[shortdesc] [nvarchar](250) NULL,
	[longdesc] [nvarchar](max) NULL,
	[sortseq] [int] NOT NULL,
	[dateadded] [datetime] NULL,
	[birthplace] [nvarchar](100) NULL,
	[birthname] [nvarchar](100) NULL,
	[deathmonth] [int] NULL,
	[deathday] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settings]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[pKey] [nchar](10) NOT NULL,
	[pValue] [nvarchar](250) NOT NULL,
	[pType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[pKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SocialMedia]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMedia](
	[personId] [int] NOT NULL,
	[twitterHandle] [nvarchar](50) NULL,
	[noTweet] [bit] NULL,
 CONSTRAINT [PK_SocialMedia] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tweets]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tweets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tweetDateSent] [datetime] NULL,
	[tweetText] [nvarchar](280) NULL,
	[tweetMonth] [int] NULL,
	[tweetDay] [int] NULL,
	[tweetSeq] [int] NULL,
	[tweetId] [nchar](20) NULL,
 CONSTRAINT [PK_Tweets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[twitterhandles]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[twitterhandles](
	[personId] [varchar](50) NULL,
	[twitterHandle] [varchar](50) NULL,
	[noTweet] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[FullPerson]    Script Date: 06/06/2019 14:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FullPerson]
AS
SELECT        dbo.Person.longdesc, dbo.Person.shortdesc, dbo.Person.deathyear, dbo.Person.birthday, dbo.Person.birthmonth, dbo.Person.birthyear, dbo.Person.surname, 
                         dbo.Person.forename, dbo.Person.id, dbo.Person.sortseq, dbo.Person.dateadded, dbo.Person.birthplace, dbo.Person.birthname, dbo.Person.deathmonth, 
                         dbo.Person.deathday, dbo.Image.imgfiletype, dbo.Image.imgloadyr, dbo.Image.imgloadmonth, dbo.SocialMedia.twitterHandle, dbo.SocialMedia.noTweet, 
                         dbo.Image.imgfilename
FROM            dbo.Person LEFT OUTER JOIN
                         dbo.Image ON dbo.Person.id = dbo.Image.id LEFT OUTER JOIN
                         dbo.SocialMedia ON dbo.Person.id = dbo.SocialMedia.personId

GO
/****** Object:  Index [IX_Dates]    Script Date: 06/06/2019 14:38:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Dates] ON [dbo].[Dates]
(
	[bday] ASC,
	[bmonth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
         Begin Table = "Image"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 196
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SocialMedia"
            Begin Extent = 
               Top = 10
               Left = 624
               Bottom = 138
               Right = 823
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Person"
            Begin Extent = 
               Top = 6
               Left = 332
               Bottom = 276
               Right = 539
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FullPerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FullPerson'
GO
USE [master]
GO
ALTER DATABASE [CelebrityBirthday] SET  READ_WRITE 
GO
