USE [master]
GO
/****** Object:  Database [Store]    Script Date: 11/19/2016 3:21:08 AM ******/
CREATE DATABASE [Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Store', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Store.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Store_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Store_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Store] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Store] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Store] SET RECOVERY FULL 
GO
ALTER DATABASE [Store] SET  MULTI_USER 
GO
ALTER DATABASE [Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Store] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Store', N'ON'
GO
USE [Store]
GO
/****** Object:  Table [dbo].[Bill_orders]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill_orders](
	[bill_id] [int] IDENTITY(1,1) NOT NULL,
	[total_price] [decimal](18, 0) NOT NULL,
	[bill_date] [date] NOT NULL,
 CONSTRAINT [PK_Bill_orders] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Branches]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[b_id] [int] IDENTITY(1,1) NOT NULL,
	[b_name] [nvarchar](150) NOT NULL,
	[w_id] [int] NOT NULL,
	[mobile] [nvarchar](20) NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[b_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [nvarchar](250) NOT NULL,
	[b_id] [int] NOT NULL,
	[c_photo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[it_id] [int] IDENTITY(1,1) NOT NULL,
	[it_name] [nvarchar](250) NOT NULL,
	[c_id] [int] NOT NULL,
	[price_a_discount] [decimal](18, 0) NOT NULL,
	[price_b_discound] [decimal](18, 0) NOT NULL,
	[it_photo] [nvarchar](max) NOT NULL,
	[it_quantity] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[it_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ord_id] [int] IDENTITY(1,1) NOT NULL,
	[it_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price_per_quantity] [decimal](18, 0) NOT NULL,
	[bill_id] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ord_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareHouses]    Script Date: 11/19/2016 3:21:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouses](
	[w_id] [int] IDENTITY(1,1) NOT NULL,
	[w_name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_WareHouses] PRIMARY KEY CLUSTERED 
(
	[w_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_WareHouses] FOREIGN KEY([w_id])
REFERENCES [dbo].[WareHouses] ([w_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Branches_WareHouses]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Branches] FOREIGN KEY([b_id])
REFERENCES [dbo].[Branches] ([b_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Branches]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([c_id])
REFERENCES [dbo].[Categories] ([c_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Bill_orders] FOREIGN KEY([bill_id])
REFERENCES [dbo].[Bill_orders] ([bill_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Bill_orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Items1] FOREIGN KEY([it_id])
REFERENCES [dbo].[Items] ([it_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Items1]
GO
USE [master]
GO
ALTER DATABASE [Store] SET  READ_WRITE 
GO
