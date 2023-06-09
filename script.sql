USE [master]
GO
/****** Object:  Database [Credits]    Script Date: 24.04.2023 15:07:39 ******/
CREATE DATABASE [Credits]

GO
USE [Credits]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 24.04.2023 15:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](200) NOT NULL,
	[KindPropertyId] [int] NOT NULL,
	[Adress] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](200) NOT NULL,
	[ContactFace] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credits]    Script Date: 24.04.2023 15:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credits](
	[CreditId] [int] IDENTITY(1,1) NOT NULL,
	[KindCreditId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[CreditSumm] [decimal](18, 0) NOT NULL,
	[DateOfIssue] [date] NOT NULL,
 CONSTRAINT [PK_Credits] PRIMARY KEY CLUSTERED 
(
	[CreditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KindCredits]    Script Date: 24.04.2023 15:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KindCredits](
	[KindCreditId] [int] IDENTITY(1,1) NOT NULL,
	[KindCreditName] [nvarchar](200) NOT NULL,
	[Conditions] [nvarchar](200) NOT NULL,
	[Rate] [int] NOT NULL,
	[Term] [int] NOT NULL,
 CONSTRAINT [PK_KindCredits] PRIMARY KEY CLUSTERED 
(
	[KindCreditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KindProperties]    Script Date: 24.04.2023 15:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KindProperties](
	[KindPropertyId] [int] IDENTITY(1,1) NOT NULL,
	[KindPropertyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KindProperties] PRIMARY KEY CLUSTERED 
(
	[KindPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientId], [ClientName], [KindPropertyId], [Adress], [Phone], [ContactFace]) VALUES (1, N'Премиум сервис', 1, N'Фрунзе 1-34', N'76858698', N'Иванов')
INSERT [dbo].[Clients] ([ClientId], [ClientName], [KindPropertyId], [Adress], [Phone], [ContactFace]) VALUES (2, N'ТК "Зелень"', 2, N'Северная 3-45', N'76885778', N'Петров')
INSERT [dbo].[Clients] ([ClientId], [ClientName], [KindPropertyId], [Adress], [Phone], [ContactFace]) VALUES (3, N'АО "Компания"', 3, N'Южная 4-67', N'77666', N'Сидоров')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Credits] ON 

INSERT [dbo].[Credits] ([CreditId], [KindCreditId], [ClientId], [CreditSumm], [DateOfIssue]) VALUES (1, 2, 1, CAST(1000000 AS Decimal(18, 0)), CAST(N'2034-05-23' AS Date))
INSERT [dbo].[Credits] ([CreditId], [KindCreditId], [ClientId], [CreditSumm], [DateOfIssue]) VALUES (3, 1, 2, CAST(10000000 AS Decimal(18, 0)), CAST(N'2025-04-23' AS Date))
INSERT [dbo].[Credits] ([CreditId], [KindCreditId], [ClientId], [CreditSumm], [DateOfIssue]) VALUES (4, 2, 3, CAST(5000000 AS Decimal(18, 0)), CAST(N'2020-06-04' AS Date))
SET IDENTITY_INSERT [dbo].[Credits] OFF
GO
SET IDENTITY_INSERT [dbo].[KindCredits] ON 

INSERT [dbo].[KindCredits] ([KindCreditId], [KindCreditName], [Conditions], [Rate], [Term]) VALUES (1, N'Инвестиционный', N'Минимальный кредит от 5000000', 10000000, 10)
INSERT [dbo].[KindCredits] ([KindCreditId], [KindCreditName], [Conditions], [Rate], [Term]) VALUES (2, N'Бизнес - ипотека', N'от 2 лет уменьшается размер выплаты', 100000000, 15)
SET IDENTITY_INSERT [dbo].[KindCredits] OFF
GO
SET IDENTITY_INSERT [dbo].[KindProperties] ON 

INSERT [dbo].[KindProperties] ([KindPropertyId], [KindPropertyName]) VALUES (1, N'личная')
INSERT [dbo].[KindProperties] ([KindPropertyId], [KindPropertyName]) VALUES (2, N'частная')
INSERT [dbo].[KindProperties] ([KindPropertyId], [KindPropertyName]) VALUES (3, N'смешанная')
SET IDENTITY_INSERT [dbo].[KindProperties] OFF
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_KindProperties] FOREIGN KEY([KindPropertyId])
REFERENCES [dbo].[KindProperties] ([KindPropertyId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_KindProperties]
GO
ALTER TABLE [dbo].[Credits]  WITH CHECK ADD  CONSTRAINT [FK_Credits_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Credits] CHECK CONSTRAINT [FK_Credits_Clients]
GO
ALTER TABLE [dbo].[Credits]  WITH CHECK ADD  CONSTRAINT [FK_Credits_KindCredits] FOREIGN KEY([KindCreditId])
REFERENCES [dbo].[KindCredits] ([KindCreditId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Credits] CHECK CONSTRAINT [FK_Credits_KindCredits]
GO
USE [master]
GO
ALTER DATABASE [Credits] SET  READ_WRITE 
GO
