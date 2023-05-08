# ForceGet

# please write your servername here in appsettings.json "ForceGetConnectionString": "Server=xxx;Database=ForceGet;Trusted_Connection=True;"

# before start the project you need to execute the scripts below on ms sql server.

CREATE DATABASE ForceGet

GO

USE [ForceGet]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Offer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mode] [varchar](10) NULL,
	[MovementType] [varchar](50) NULL,
	[CountriesCities] [varchar](80) NULL,
	[Incoterm] [varchar](50) NULL,
	[PackageType] [varchar](50) NULL,
	[Unit1] [varchar](50) NULL,
	[Unit2] [varchar](50) NULL,
	[Currency] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


# if web api does not work please check your localhost port for the api and then correct the url in appsettings.json   "OfferServiceBaseUrl": "https://localhost:7065/api/Offer/",   just check the port 7065 if it is not correct then write the true value for this url.
