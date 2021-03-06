USE [master]
GO
/****** Object:  Database [Nadhemni]    Script Date: 02/06/2020 23:13:16 ******/
CREATE DATABASE [Nadhemni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nadhemni', FILENAME = N'C:\Users\HP\Desktop\MSSQL14.MSSQLSERVER\MSSQL\DATA\Nadhemni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ),
( NAME = N'nadhemnii', FILENAME = N'C:\Users\HP\Desktop\MSSQL14.MSSQLSERVER\MSSQL\DATA\nadhemnii.ndf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nadhemni_log', FILENAME = N'C:\Users\HP\Desktop\MSSQL14.MSSQLSERVER\MSSQL\DATA\Nadhemni_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Nadhemni] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nadhemni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nadhemni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nadhemni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nadhemni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nadhemni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nadhemni] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nadhemni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nadhemni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nadhemni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nadhemni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nadhemni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nadhemni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nadhemni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nadhemni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nadhemni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nadhemni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nadhemni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nadhemni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nadhemni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nadhemni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nadhemni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nadhemni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nadhemni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nadhemni] SET RECOVERY FULL 
GO
ALTER DATABASE [Nadhemni] SET  MULTI_USER 
GO
ALTER DATABASE [Nadhemni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nadhemni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nadhemni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nadhemni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nadhemni] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nadhemni', N'ON'
GO
ALTER DATABASE [Nadhemni] SET QUERY_STORE = OFF
GO
USE [Nadhemni]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 02/06/2020 23:13:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id_Bills] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[DateC] [date] NOT NULL,
	[TypeC] [varchar](50) NOT NULL,
	[Beneficiary] [varchar](50) NULL,
	[Amount] [float] NOT NULL,
	[State] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Bills] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[petreminder]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[petreminder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RemName] [nvarchar](50) NOT NULL,
	[remdate] [datetime] NULL,
	[State] [varchar](50) NULL,
 CONSTRAINT [PK_petreminder] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id_Event] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[DateEvent] [date] NOT NULL,
	[Titre] [varchar](50) NOT NULL,
	[Organiser] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Type] [varchar](50) NULL,
	[Etat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Event] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RDV]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RDV](
	[Id_RDV] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[DateRDV] [datetime] NOT NULL,
	[Membre] [varchar](50) NULL,
	[Etat] [varchar](50) NULL,
	[Nom_RDV] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_RDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Planning]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Planning]
	AS SELECT Id_user,Etat as et, Titre as nom,DateEvent  FROM [Event]
	UNION ALL
	SELECT Id_user,Etat as et,  Membre as nom,DateRDV as DateEvent FROM [RDV]
	UNION ALL 
	select Id_user,State as et, Beneficiary as nom,DateC as DateEvent from[Bill]
	UNION all
	select Id_user,State as et,  RemName as nom,remdate as DateEvent  from[petreminder]
GO
/****** Object:  Table [dbo].[Pet]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pet](
	[Id_User] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[birthday] [date] NULL,
	[veto_name] [nvarchar](50) NULL,
	[veto_number] [nvarchar](50) NULL,
	[photo] [image] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desire]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desire](
	[id_Desire] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[Choice] [varchar](50) NOT NULL,
	[Cost] [decimal](20, 3) NOT NULL,
	[Savings] [decimal](20, 3) NOT NULL,
	[Deadline] [date] NOT NULL,
	[Frequency] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Desire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[id_Family] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[FamilyMember] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Dbrth] [date] NOT NULL,
	[Dead] [int] NULL,
	[LIvesWithMe] [int] NULL,
	[study] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Family] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Planning-date]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Planning-date]
	AS SELECT Titre,DateEvent FROM [Event]
	where DATEDIFF(day,getdate() , DateEvent)<0
	UNION ALL
	SELECT Membre,DateRDV FROM [RDV]
	where DATEDIFF(day,getdate(), DateRDV)<0
	UNION ALL 
	select Beneficiary,DateC from[Bill]
	where DATEDIFF(day,getdate(), DateC)<0
	UNION all
	select Name,Birthday from [Pet]
	where DATEDIFF(day,getdate(), birthday)<0
	union all
	select RemName ,remdate from[petreminder]
	where DATEDIFF(day,getdate(), remdate)<0
	union all
	select Choice, Deadline from [Desire]
	where DATEDIFF(day,getdate(), Deadline)<0	
	union all
	select FamilyMember, Dbrth from [Family]
	where DATEDIFF(day,getdate(), Dbrth)<0
GO
/****** Object:  View [dbo].[Planning-No]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Planning-No]
	AS SELECT Id_user,Titre,DateEvent FROM [Event]
	where DATEDIFF(day,getdate() , DateEvent)>0
	UNION ALL
	SELECT id_user,Membre,DateRDV FROM [RDV]
	where DATEDIFF(day,getdate(), DateRDV)>0
	UNION ALL 
	select Id_user,Beneficiary,DateC from[Bill]
	where DATEDIFF(day,getdate(), DateC)>0
	UNION all
	select Id_User,Name,Birthday from [Pet]
	where DATEDIFF(day,getdate(), birthday)>0
	union all
	select Id_User,RemName ,remdate from[petreminder]
	where DATEDIFF(day,getdate(), remdate)>0
	union all
	select Id_user,Choice, Deadline from [Desire]
	where DATEDIFF(day,getdate(), Deadline)>0	
	union all
	select Id_user,FamilyMember, Dbrth from [Family]
	where DATEDIFF(day,getdate(), Dbrth)>0
GO
/****** Object:  Table [dbo].[BeautyTb]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeautyTb](
	[id_Beauty] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NULL,
	[DayB] [varchar](11) NOT NULL,
	[TimeB] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Beauty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diseases]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[Id_Di] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[time] [nvarchar](50) NULL,
	[NameM] [nvarchar](50) NULL,
	[Med] [nvarchar](50) NULL,
 CONSTRAINT [PK_Diseases] PRIMARY KEY CLUSTERED 
(
	[Id_Di] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrinkWater]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrinkWater](
	[Id_water] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NOT NULL,
	[Quantity] [nvarchar](50) NULL,
	[PeriodDrink] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_water] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drugs]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drugs](
	[Id_Drugs] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[Id_Family] [int] NOT NULL,
	[Period] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Drugs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[Id_TimeTable] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[Id_Family] [int] NULL,
	[day] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[content] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TimeTable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/06/2020 23:13:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_user] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[DBth] [date] NOT NULL,
	[Profession] [varchar](50) NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[Situation] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ProfilePicture] [varchar](70) NULL,
	[Country] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ('waiting') FOR [State]
GO
ALTER TABLE [dbo].[Event] ADD  DEFAULT ('waiting') FOR [Etat]
GO
ALTER TABLE [dbo].[petreminder] ADD  DEFAULT ('waiting') FOR [State]
GO
ALTER TABLE [dbo].[RDV] ADD  DEFAULT ('waiting') FOR [Etat]
GO
ALTER TABLE [dbo].[BeautyTb]  WITH CHECK ADD  CONSTRAINT [FK_IdUserBeautyTb] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BeautyTb] CHECK CONSTRAINT [FK_IdUserBeautyTb]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_IdUserBill] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_IdUserBill]
GO
ALTER TABLE [dbo].[Desire]  WITH CHECK ADD  CONSTRAINT [FK_IdUserDesire] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Desire] CHECK CONSTRAINT [FK_IdUserDesire]
GO
ALTER TABLE [dbo].[Diseases]  WITH NOCHECK ADD  CONSTRAINT [FK_Diseases_Users] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_Users]
GO
ALTER TABLE [dbo].[DrinkWater]  WITH NOCHECK ADD  CONSTRAINT [FK_DrinkWater_ToTable] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[DrinkWater] CHECK CONSTRAINT [FK_DrinkWater_ToTable]
GO
ALTER TABLE [dbo].[Drugs]  WITH CHECK ADD  CONSTRAINT [FK_Family_Drugs] FOREIGN KEY([Id_Family])
REFERENCES [dbo].[Family] ([id_Family])
GO
ALTER TABLE [dbo].[Drugs] CHECK CONSTRAINT [FK_Family_Drugs]
GO
ALTER TABLE [dbo].[Event]  WITH NOCHECK ADD  CONSTRAINT [FK_Event_ToTable] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_ToTable]
GO
ALTER TABLE [dbo].[Family]  WITH NOCHECK ADD  CONSTRAINT [FK_IdUserFamily] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Family] CHECK CONSTRAINT [FK_IdUserFamily]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [FK_Pet_ToTable] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [FK_Pet_ToTable]
GO
ALTER TABLE [dbo].[petreminder]  WITH CHECK ADD  CONSTRAINT [FK_petreminder_ToTable] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[petreminder] CHECK CONSTRAINT [FK_petreminder_ToTable]
GO
ALTER TABLE [dbo].[RDV]  WITH NOCHECK ADD  CONSTRAINT [FK_RDV_ToTable] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[RDV] CHECK CONSTRAINT [FK_RDV_ToTable]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_IdUserTimeF] FOREIGN KEY([Id_Family])
REFERENCES [dbo].[Family] ([id_Family])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_IdUserTimeF]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_IdUserTimeTableU] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([Id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_IdUserTimeTableU]
GO
USE [master]
GO
ALTER DATABASE [Nadhemni] SET  READ_WRITE 
GO
