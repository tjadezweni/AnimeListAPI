USE [master]
GO
/****** Object:  Database [AnimeListDB]    Script Date: 2022/04/06 06:28:22 ******/
CREATE DATABASE [AnimeListDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnimeListDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AnimeListDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AnimeListDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AnimeListDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AnimeListDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnimeListDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnimeListDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AnimeListDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AnimeListDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AnimeListDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AnimeListDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AnimeListDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AnimeListDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnimeListDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnimeListDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnimeListDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AnimeListDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AnimeListDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnimeListDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AnimeListDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnimeListDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AnimeListDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnimeListDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnimeListDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnimeListDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnimeListDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnimeListDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AnimeListDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnimeListDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AnimeListDB] SET  MULTI_USER 
GO
ALTER DATABASE [AnimeListDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnimeListDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnimeListDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnimeListDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AnimeListDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AnimeListDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AnimeListDB', N'ON'
GO
ALTER DATABASE [AnimeListDB] SET QUERY_STORE = OFF
GO
USE [AnimeListDB]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2022/04/06 06:28:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 2022/04/06 06:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 2022/04/06 06:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2022/04/06 06:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[YearReleased] [datetime2](7) NOT NULL,
	[GenreId] [int] NOT NULL,
	[StudioId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 2022/04/06 06:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[SeriesId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Seasons] [int] NOT NULL,
	[Episodes] [int] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[YearStarted] [datetime2](7) NOT NULL,
	[YearEnded] [datetime2](7) NOT NULL,
	[GenreId] [int] NOT NULL,
	[StudioId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[SeriesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studios]    Script Date: 2022/04/06 06:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studios](
	[StudioId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Studios] PRIMARY KEY CLUSTERED 
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_CountryId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_CountryId] ON [dbo].[Movies]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_GenreId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_GenreId] ON [dbo].[Movies]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_LanguageId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_LanguageId] ON [dbo].[Movies]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_StudioId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_StudioId] ON [dbo].[Movies]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Series_CountryId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Series_CountryId] ON [dbo].[Series]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Series_GenreId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Series_GenreId] ON [dbo].[Series]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Series_LanguageId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Series_LanguageId] ON [dbo].[Series]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Series_StudioId]    Script Date: 2022/04/06 06:28:23 ******/
CREATE NONCLUSTERED INDEX [IX_Series_StudioId] ON [dbo].[Series]
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Countries_CountryId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres_GenreId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Languages_LanguageId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([StudioId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Studios_StudioId]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Countries_CountryId]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Genres_GenreId]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Languages_LanguageId]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Studios_StudioId] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studios] ([StudioId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Studios_StudioId]
GO
USE [master]
GO
ALTER DATABASE [AnimeListDB] SET  READ_WRITE 
GO
