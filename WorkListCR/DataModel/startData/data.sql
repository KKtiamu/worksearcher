USE [workSearсher]
GO
ALTER TABLE [dbo].[VM] DROP CONSTRAINT [FK_VM_uradPrace]
GO
ALTER TABLE [dbo].[VM] DROP CONSTRAINT [FK_VM_prof]
GO
ALTER TABLE [dbo].[VM] DROP CONSTRAINT [FK_VM_obec]
GO
ALTER TABLE [dbo].[prof] DROP CONSTRAINT [FK_prof_obor]
GO
ALTER TABLE [dbo].[obec] DROP CONSTRAINT [FK_obec_okres]
GO
ALTER TABLE [dbo].[coobec] DROP CONSTRAINT [FK_coobec_obec]
GO
/****** Object:  Table [dbo].[vzdelan]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[vzdelan]
GO
/****** Object:  Table [dbo].[VM]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[VM]
GO
/****** Object:  Table [dbo].[uradPrace]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[uradPrace]
GO
/****** Object:  Table [dbo].[typZamest]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[typZamest]
GO
/****** Object:  Table [dbo].[smeny]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[smeny]
GO
/****** Object:  Table [dbo].[prof]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[prof]
GO
/****** Object:  Table [dbo].[pracVztah]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[pracVztah]
GO
/****** Object:  Table [dbo].[okres]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[okres]
GO
/****** Object:  Table [dbo].[obor]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[obor]
GO
/****** Object:  Table [dbo].[obec]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[obec]
GO
/****** Object:  Table [dbo].[jazyk]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[jazyk]
GO
/****** Object:  Table [dbo].[files]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[files]
GO
/****** Object:  Table [dbo].[coobec]    Script Date: 18.09.2016 17:51:20 ******/
DROP TABLE [dbo].[coobec]
GO
USE [master]
GO
/****** Object:  Database [workSearсher]    Script Date: 18.09.2016 17:51:20 ******/
DROP DATABASE [workSearсher]
GO
/****** Object:  Database [workSearсher]    Script Date: 18.09.2016 17:51:20 ******/
CREATE DATABASE [workSearсher]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'workSearher', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\workSearher.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'workSearher_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\workSearher_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [workSearсher] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [workSearсher].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [workSearсher] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [workSearсher] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [workSearсher] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [workSearсher] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [workSearсher] SET ARITHABORT OFF 
GO
ALTER DATABASE [workSearсher] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [workSearсher] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [workSearсher] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [workSearсher] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [workSearсher] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [workSearсher] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [workSearсher] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [workSearсher] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [workSearсher] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [workSearсher] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [workSearсher] SET  DISABLE_BROKER 
GO
ALTER DATABASE [workSearсher] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [workSearсher] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [workSearсher] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [workSearсher] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [workSearсher] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [workSearсher] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [workSearсher] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [workSearсher] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [workSearсher] SET  MULTI_USER 
GO
ALTER DATABASE [workSearсher] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [workSearсher] SET DB_CHAINING OFF 
GO
ALTER DATABASE [workSearсher] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [workSearсher] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [workSearсher]
GO
/****** Object:  Table [dbo].[coobec]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coobec](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[psc] [nvarchar](10) NOT NULL,
	[idObec] [int] NOT NULL,
 CONSTRAINT [PK_coobec] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[files]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[jazyk]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jazyk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_jazyk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obec]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obec](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[idOkres] [int] NOT NULL,
 CONSTRAINT [PK_obec] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[obor]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[obor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUp] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_obor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[okres]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[okres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_okres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pracVztah]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pracVztah](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_pracVztah] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[prof]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prof](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
	[idObor] [int] NOT NULL,
 CONSTRAINT [PK_prof] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[smeny]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[smeny](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_smeny] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[typZamest]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typZamest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_typZamest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[uradPrace]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uradPrace](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_uradPrace] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VM]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VM](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
	[idProf] [int] NOT NULL,
	[firma] [nvarchar](50) NOT NULL,
	[adres] [nvarchar](250) NOT NULL,
	[idSmena] [int] NULL,
	[idVzdelani] [int] NULL,
	[idPracVztah] [int] NULL,
	[idObce] [int] NULL,
	[kontakt] [nvarchar](250) NULL,
	[mzdaOd] [int] NULL,
	[mzdaDo] [int] NULL,
	[od] [date] NULL,
	[do] [date] NULL,
	[idTyp] [int] NULL,
	[idUP] [int] NOT NULL,
	[modryKarty] [int] NULL,
	[zamestnKarty] [int] NULL,
	[dateAktual] [date] NULL,
	[volnychMist] [int] NOT NULL,
	[idJazyka] [nvarchar](50) NULL,
	[poznamka] [nvarchar](max) NULL,
 CONSTRAINT [PK_VM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vzdelan]    Script Date: 18.09.2016 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vzdelan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[kodUP] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_vzdelan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[pracVztah] ON 

INSERT [dbo].[pracVztah] ([id], [name]) VALUES (1, N'Plný')
INSERT [dbo].[pracVztah] ([id], [name]) VALUES (2, N'Zkrácený')
INSERT [dbo].[pracVztah] ([id], [name]) VALUES (3, N'dpp')
INSERT [dbo].[pracVztah] ([id], [name]) VALUES (4, N'dpc')
INSERT [dbo].[pracVztah] ([id], [name]) VALUES (5, N'Služební poměr')
SET IDENTITY_INSERT [dbo].[pracVztah] OFF
SET IDENTITY_INSERT [dbo].[typZamest] ON 

INSERT [dbo].[typZamest] ([id], [name]) VALUES (1, N'absolventySs')
INSERT [dbo].[typZamest] ([id], [name]) VALUES (2, N'absolventyVs')
INSERT [dbo].[typZamest] ([id], [name]) VALUES (3, N'ozp')
INSERT [dbo].[typZamest] ([id], [name]) VALUES (4, N'bezbar')
INSERT [dbo].[typZamest] ([id], [name]) VALUES (5, N'cizince')
INSERT [dbo].[typZamest] ([id], [name]) VALUES (6, N'azylanty')
SET IDENTITY_INSERT [dbo].[typZamest] OFF
ALTER TABLE [dbo].[coobec]  WITH CHECK ADD  CONSTRAINT [FK_coobec_obec] FOREIGN KEY([idObec])
REFERENCES [dbo].[obec] ([id])
GO
ALTER TABLE [dbo].[coobec] CHECK CONSTRAINT [FK_coobec_obec]
GO
ALTER TABLE [dbo].[obec]  WITH CHECK ADD  CONSTRAINT [FK_obec_okres] FOREIGN KEY([idOkres])
REFERENCES [dbo].[okres] ([id])
GO
ALTER TABLE [dbo].[obec] CHECK CONSTRAINT [FK_obec_okres]
GO
ALTER TABLE [dbo].[prof]  WITH CHECK ADD  CONSTRAINT [FK_prof_obor] FOREIGN KEY([idObor])
REFERENCES [dbo].[obor] ([id])
GO
ALTER TABLE [dbo].[prof] CHECK CONSTRAINT [FK_prof_obor]
GO
ALTER TABLE [dbo].[VM]  WITH CHECK ADD  CONSTRAINT [FK_VM_obec] FOREIGN KEY([idObce])
REFERENCES [dbo].[obec] ([id])
GO
ALTER TABLE [dbo].[VM] CHECK CONSTRAINT [FK_VM_obec]
GO
ALTER TABLE [dbo].[VM]  WITH CHECK ADD  CONSTRAINT [FK_VM_prof] FOREIGN KEY([idProf])
REFERENCES [dbo].[prof] ([id])
GO
ALTER TABLE [dbo].[VM] CHECK CONSTRAINT [FK_VM_prof]
GO
ALTER TABLE [dbo].[VM]  WITH CHECK ADD  CONSTRAINT [FK_VM_uradPrace] FOREIGN KEY([idUP])
REFERENCES [dbo].[uradPrace] ([id])
GO
ALTER TABLE [dbo].[VM] CHECK CONSTRAINT [FK_VM_uradPrace]
GO
USE [master]
GO
ALTER DATABASE [workSearсher] SET  READ_WRITE 
GO
