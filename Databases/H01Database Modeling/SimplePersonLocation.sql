USE [master]
GO
/****** Object:  Database [SimplePersonLocation]    Script Date: 10.7.2013 г. 18:56:16 ч. ******/
CREATE DATABASE [SimplePersonLocation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimplePersonLocation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimplePersonLocation.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimplePersonLocation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SimplePersonLocation_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SimplePersonLocation] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimplePersonLocation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimplePersonLocation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SimplePersonLocation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimplePersonLocation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimplePersonLocation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimplePersonLocation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimplePersonLocation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET RECOVERY FULL 
GO
ALTER DATABASE [SimplePersonLocation] SET  MULTI_USER 
GO
ALTER DATABASE [SimplePersonLocation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimplePersonLocation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimplePersonLocation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimplePersonLocation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimplePersonLocation', N'ON'
GO
USE [SimplePersonLocation]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10.7.2013 г. 18:56:16 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 10.7.2013 г. 18:56:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10.7.2013 г. 18:56:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 10.7.2013 г. 18:56:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10.7.2013 г. 18:56:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'200 Broadway Av WEST BEACH SA 5024   ', 7)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (4, N'134 Broadway Av South BEACH SA 5024   ', 7)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (5, N'134 Broadway Av South BEACH SA 5024   ', 6)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (6, N'134 Broadway Av South BEACH SA 5024   ', 8)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (11, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (10, N'Antarctica')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (8, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (9, N'Australia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (5, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (7, N'North America')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (6, N'South America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (2, N'Bulgaria', 5)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (3, N'Austria', 5)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (4, N'Germany', 5)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (5, N'Mexico', 6)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (6, N'Mexico', 7)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (7, N'Canada', 7)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (8, N'Botswana', 11)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (9, N'Algeria', 11)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (8, N'Lili', N'Pesheva', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (9, N'Pesho', N'Georgiev', 4)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (10, N'Oleg', N'Peshev', 5)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (11, N'Niki', N'Ivanov', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (12, N'Bobi', N'Peshev', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (13, N'Ivo', N'Mihajlov', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (14, N'Dilian', N'Peshev', 3)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (5, N'Mexico City', 6)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (6, N'Sofia', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (7, N'Pleven', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (8, N'Plovdiv', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (9, N'Vidin', 2)
SET IDENTITY_INSERT [dbo].[Towns] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Continents]    Script Date: 10.7.2013 г. 18:56:17 ч. ******/
ALTER TABLE [dbo].[Continents] ADD  CONSTRAINT [IX_Continents] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [SimplePersonLocation] SET  READ_WRITE 
GO
