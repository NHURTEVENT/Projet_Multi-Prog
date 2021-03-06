USE [master]
GO
/****** Object:  Database [multiprog]    Script Date: 09/12/2018 22:53:00 ******/
CREATE DATABASE [multiprog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'multiprog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\multiprog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'multiprog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\multiprog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [multiprog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [multiprog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [multiprog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [multiprog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [multiprog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [multiprog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [multiprog] SET ARITHABORT OFF 
GO
ALTER DATABASE [multiprog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [multiprog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [multiprog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [multiprog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [multiprog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [multiprog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [multiprog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [multiprog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [multiprog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [multiprog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [multiprog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [multiprog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [multiprog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [multiprog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [multiprog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [multiprog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [multiprog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [multiprog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [multiprog] SET  MULTI_USER 
GO
ALTER DATABASE [multiprog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [multiprog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [multiprog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [multiprog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [multiprog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [multiprog] SET QUERY_STORE = OFF
GO
USE [multiprog]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drawers]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drawers](
	[UtensilType] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Drawers] PRIMARY KEY CLUSTERED 
(
	[UtensilType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemDBEntries]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemDBEntries](
	[ItemType] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ItemDBEntries] PRIMARY KEY CLUSTERED 
(
	[ItemType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MachineDBEntries]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineDBEntries](
	[MachineId] [int] IDENTITY(1,1) NOT NULL,
	[MachineType] [nvarchar](max) NULL,
	[MaxCapacity] [int] NOT NULL,
	[MinCapacity] [int] NOT NULL,
	[RunningTime] [int] NOT NULL,
	[UnloadingTime] [int] NOT NULL,
	[LoadingTime] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MachineDBEntries] PRIMARY KEY CLUSTERED 
(
	[MachineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonnelDBEntries]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonnelDBEntries](
	[PersonnelType] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PersonnelDBEntries] PRIMARY KEY CLUSTERED 
(
	[PersonnelType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeSteps]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeSteps](
	[Dish] [int] NOT NULL,
	[Step] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Utensil] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RecipeSteps] PRIMARY KEY CLUSTERED 
(
	[Dish] ASC,
	[Step] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableDBEntries]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableDBEntries](
	[Square] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[Column] [int] NOT NULL,
	[Size] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TableDBEntries] PRIMARY KEY CLUSTERED 
(
	[Square] ASC,
	[Row] ASC,
	[Column] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UtensilEntries]    Script Date: 09/12/2018 22:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UtensilEntries](
	[Quantity] [int] NOT NULL,
	[UtensilType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UtensilEntries] PRIMARY KEY CLUSTERED 
(
	[UtensilType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Utensil]    Script Date: 09/12/2018 22:53:00 ******/
CREATE NONCLUSTERED INDEX [IX_Utensil] ON [dbo].[RecipeSteps]
(
	[Utensil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UtensilEntries] ADD  DEFAULT ((0)) FOR [UtensilType]
GO
ALTER TABLE [dbo].[RecipeSteps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RecipeSteps_dbo.UtensilEntries_Utensil] FOREIGN KEY([Utensil])
REFERENCES [dbo].[UtensilEntries] ([UtensilType])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeSteps] CHECK CONSTRAINT [FK_dbo.RecipeSteps_dbo.UtensilEntries_Utensil]
GO
USE [master]
GO
ALTER DATABASE [multiprog] SET  READ_WRITE 
GO
