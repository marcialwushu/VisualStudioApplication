USE [master]
GO

/****** Object:  Database [AgendaContato]    Script Date: 10/05/2017 03:11:01 ******/
CREATE DATABASE [AgendaContato]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AgendaContato', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AgendaContato.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AgendaContato_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AgendaContato_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [AgendaContato] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AgendaContato].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AgendaContato] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AgendaContato] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AgendaContato] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AgendaContato] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AgendaContato] SET ARITHABORT OFF 
GO

ALTER DATABASE [AgendaContato] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AgendaContato] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AgendaContato] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AgendaContato] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AgendaContato] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AgendaContato] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AgendaContato] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AgendaContato] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AgendaContato] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AgendaContato] SET  ENABLE_BROKER 
GO

ALTER DATABASE [AgendaContato] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AgendaContato] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AgendaContato] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AgendaContato] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AgendaContato] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AgendaContato] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AgendaContato] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AgendaContato] SET RECOVERY FULL 
GO

ALTER DATABASE [AgendaContato] SET  MULTI_USER 
GO

ALTER DATABASE [AgendaContato] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AgendaContato] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AgendaContato] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AgendaContato] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [AgendaContato] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AgendaContato] SET  READ_WRITE 
GO

