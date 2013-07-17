USE [master]
GO

CREATE DATABASE [Problem2-World]
 CONTAINMENT = NONE

 GO
ALTER DATABASE [Problem2-World] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Problem2-World].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Problem2-World] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Problem2-World] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Problem2-World] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Problem2-World] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Problem2-World] SET ARITHABORT OFF 
GO
ALTER DATABASE [Problem2-World] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Problem2-World] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Problem2-World] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Problem2-World] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Problem2-World] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Problem2-World] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Problem2-World] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Problem2-World] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Problem2-World] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Problem2-World] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Problem2-World] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Problem2-World] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Problem2-World] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Problem2-World] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Problem2-World] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Problem2-World] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Problem2-World] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Problem2-World] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Problem2-World] SET RECOVERY FULL 
GO
ALTER DATABASE [Problem2-World] SET  MULTI_USER 
GO
ALTER DATABASE [Problem2-World] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Problem2-World] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Problem2-World] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Problem2-World] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Problem2-World', N'ON'
GO
USE [Problem2-World]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 7/10/2013 12:08:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NULL,
	[TownId] [int] NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 7/10/2013 12:08:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7/10/2013 12:08:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[ContinentsId] [int] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 7/10/2013 12:08:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 7/10/2013 12:08:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (1, N'Marica str. 28', 2)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'Tasrigradsko chaussee 15', 2)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (4, N'NorthAmerica')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (5, N'SouthAmerica')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (6, N'Antarctica')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (7, N'Australia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentsId]) VALUES (1, N'Bulgaria', 2)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentsId]) VALUES (2, N'Nigeria', 3)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentsId]) VALUES (3, N'Egypt', 3)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentsId]) VALUES (4, N'USA', 4)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentsId]) VALUES (5, N'France', 2)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Petko', N'Petkov', 1)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Ivan', N'Ivanov', 2)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (4, N'Pyrvan', N'Pyrvanov', 1)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (1, N'Paris', 5)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (2, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (3, N'Instanbul', NULL)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (4, N'Chicago', 4)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (5, N'Varna', 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentsId])
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
ALTER DATABASE [Problem2-World] SET  READ_WRITE 
GO
