USE [master]
GO
/****** Object:  Database [TopTrumps]    Script Date: 07/05/2021 10:33:57 ******/
CREATE DATABASE [TopTrumps]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TopTrumps', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TopTrumps.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TopTrumps_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TopTrumps_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TopTrumps] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TopTrumps].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TopTrumps] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TopTrumps] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TopTrumps] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TopTrumps] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TopTrumps] SET ARITHABORT OFF 
GO
ALTER DATABASE [TopTrumps] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TopTrumps] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TopTrumps] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TopTrumps] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TopTrumps] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TopTrumps] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TopTrumps] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TopTrumps] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TopTrumps] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TopTrumps] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TopTrumps] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TopTrumps] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TopTrumps] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TopTrumps] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TopTrumps] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TopTrumps] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TopTrumps] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TopTrumps] SET RECOVERY FULL 
GO
ALTER DATABASE [TopTrumps] SET  MULTI_USER 
GO
ALTER DATABASE [TopTrumps] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TopTrumps] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TopTrumps] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TopTrumps] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TopTrumps] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TopTrumps', N'ON'
GO
ALTER DATABASE [TopTrumps] SET QUERY_STORE = OFF
GO
USE [TopTrumps]
GO
/****** Object:  User [top_trumps_user]    Script Date: 07/05/2021 10:33:58 ******/
CREATE USER [top_trumps_user] FOR LOGIN [top_trumps_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_datareader] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [top_trumps_user]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [top_trumps_user]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 07/05/2021 10:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [char](100) NOT NULL,
	[Type] [char](30) NOT NULL,
	[ABV] [decimal](3, 1) NOT NULL,
	[Accessibility] [int] NOT NULL,
	[Reputation] [int] NOT NULL,
	[Popularity] [int] NOT NULL,
	[Description] [char](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collection]    Script Date: 07/05/2021 10:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collection](
	[UserId] [int] NOT NULL,
	[CardId] [int] NOT NULL,
	[InDeck] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/05/2021 10:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[NormalizedName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/05/2021 10:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[NormalizedUserName] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersVsRoles]    Script Date: 07/05/2021 10:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersVsRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UsersVsRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (1, N'White Lightning                                                                                     ', N'Cider                         ', CAST(8.4 AS Decimal(3, 1)), 2, 2, 6, N'English white cider produced from the 1990s to 2009. Discontinued due to its brand image problem in the UK becoming synonymous with under-age drinking, homelessness and alcoholism.                                                                           ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (2, N'Stella Artois                                                                                       ', N'Belgian Pilsner               ', CAST(5.2 AS Decimal(3, 1)), 9, 4, 7, N'Originally launched as a Christmas beer, it has a well-balanced malt sweetness, crisp hop bitterness and dry finish. It has a generally unfounded perceived connection between binge drinking and domestic violence.                                           ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (3, N'Guinness                                                                                            ', N'Irish Stout                   ', CAST(4.3 AS Decimal(3, 1)), 8, 6, 9, N'First produced in, 1759. The draught features a characteristic tang and thick, creamy head. The Guinness Brewery in Dublin was the most popular tourist attraction in Ireland in 2017.                                                                         ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (4, N'Jack Daniels                                                                                        ', N'Straight Bourbon              ', CAST(40.0 AS Decimal(3, 1)), 8, 6, 7, N'This bourbon has notes of sweet vanilla, caramel, toasty oak, smoke. The standard edition is quite inexpensive compared to other bourbons. It is generally considered by bourbon drinkers as one of the least refinded of its family.                          ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (5, N'Fosters                                                                                             ', N'Pale Lager                    ', CAST(4.0 AS Decimal(3, 1)), 9, 7, 7, N'First brewed in Australia in 1889, but started mass production in England when the Courage obtained the rights to brew under the UK licence. Has a mild hoppy and malty flavour. It considered a middling and average lager.                                   ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (6, N'Gordons Gin                                                                                         ', N'Dry Gin                       ', CAST(37.2 AS Decimal(3, 1)), 8, 6, 9, N'First produced in 1769, the recipe has remained unchanged. It is triple-distilled and contains juniper berries, licorice, orange, and lemon. This gin is one of the most well known spirits on the planet and in turn is held in quite a high regard.          ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (7, N'Châteauneuf-du-Pape                                                                                 ', N'Grenache Red Wine             ', CAST(14.5 AS Decimal(3, 1)), 6, 9, 8, N'This wine comes from Southern Rhône in France, it is known for a very concentrated mix of rich aromas and flavours of black cherry, plum and spices. Generally considered one of the nicest, more refined wines on a budget.                                   ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (8, N'Lambrini                                                                                            ', N'Perry/Pear Cider              ', CAST(3.5 AS Decimal(3, 1)), 7, 3, 5, N'Although Lambrini is not a wine but a perry, it is a marketed more in the style of a wine than a traditional perry or cider. it has been associated with underage drinking, due to the cheap price and ABV.                                                    ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (9, N'Wolf Blass Chardonnay                                                                               ', N'White Chardonnay Wine         ', CAST(13.5 AS Decimal(3, 1)), 8, 7, 7, N'This chardonnay is from South Australia, and was first produced by Wolfgang Blass AM in 1966 It is medium bodied wine with a soft, creamy texture.  Generally considered a good low budget chardonnay.                                                         ')
GO
INSERT [dbo].[Cards] ([Id], [Name], [Type], [ABV], [Accessibility], [Reputation], [Popularity], [Description]) VALUES (10, N'Strongbow                                                                                           ', N'Dry Cider                     ', CAST(4.5 AS Decimal(3, 1)), 9, 6, 7, N'Created in 1960 in the UK. In 2002 after a surge of new cider drinks arose its popularity dropped. Strongbow is a blend of bitter-sweet cider and culinary apples, with 50 different varieties of apple used.                                                  ')
GO
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 1, 0)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 2, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 3, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 4, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 5, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 6, 0)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (1, 7, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (2, 1, 1)
GO
INSERT [dbo].[Collection] ([UserId], [CardId], [InDeck]) VALUES (2, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName]) VALUES (1, N'Admin', N'Administrator')
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName]) VALUES (2, N'Player', N'Player')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]) VALUES (1, N'alex.adwilson@gmail.com', N'ALEX.ADWILSON@GMAIL.COM', N'alex.adwilson@gmail.com', N'ALEX.ADWILSON@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHzAlzsUTJiROT4mauwFfgJlkVXmnrRBBoFZNFwW/m6tjN7XnHsbUsDVRpSO0Ke6qg==', NULL, 0, 0)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]) VALUES (2, N'jack@aol.com', N'JACK@AOL.COM', N'jack@aol.com', N'JACK@AOL.COM', 1, N'AQAAAAEAACcQAAAAEF3JAT26CtXhaYx2wZhP+1ykz9nL/Qh1q7NRFZPkT5xT/VPBjGQHo/BNoBugoseYXw==', NULL, 0, 0)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]) VALUES (3, N'a.b@c.com', N'A.B@C.COM', N'a.b@c.com', N'A.B@C.COM', 1, N'AQAAAAEAACcQAAAAEKDmQLwlkS0xU584vHvdEywbu8XZUydTjXjOG+LBsdAvp5XK9+LXBFuSXo/yT2YgMQ==', NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UsersVsRoles] ON 
GO
INSERT [dbo].[UsersVsRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UsersVsRoles] ([Id], [UserId], [RoleId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UsersVsRoles] ([Id], [UserId], [RoleId]) VALUES (3, 2, 2)
GO
INSERT [dbo].[UsersVsRoles] ([Id], [UserId], [RoleId]) VALUES (4, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[UsersVsRoles] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationRole_NormalizedName]    Script Date: 07/05/2021 10:33:58 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationRole_NormalizedName] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUser_NormalizedEmail]    Script Date: 07/05/2021 10:33:58 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedEmail] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUser_NormalizedUserName]    Script Date: 07/05/2021 10:33:58 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedUserName] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Collection]  WITH CHECK ADD  CONSTRAINT [FK_Collection_ApplicationUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Collection] CHECK CONSTRAINT [FK_Collection_ApplicationUser]
GO
ALTER TABLE [dbo].[Collection]  WITH CHECK ADD  CONSTRAINT [FK_Collection_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[Collection] CHECK CONSTRAINT [FK_Collection_Cards]
GO
ALTER TABLE [dbo].[UsersVsRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersVsRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UsersVsRoles] CHECK CONSTRAINT [FK_UsersVsRoles_Roles]
GO
ALTER TABLE [dbo].[UsersVsRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersVsRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersVsRoles] CHECK CONSTRAINT [FK_UsersVsRoles_Users]
GO
USE [master]
GO
ALTER DATABASE [TopTrumps] SET  READ_WRITE 
GO
