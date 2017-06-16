USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 6/16/2017 3:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 6/16/2017 3:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 6/16/2017 3:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[city] [varchar](50) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'Animal Collective')
INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Future Islands')
INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Fleet Foxes')
INSERT [dbo].[bands] ([id], [name]) VALUES (4, N'New Order')
INSERT [dbo].[bands] ([id], [name]) VALUES (5, N'Joy Division')
INSERT [dbo].[bands] ([id], [name]) VALUES (6, N'Morrissey')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 1, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 1, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 2, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 5, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 3, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 2, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 6, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 1, 7)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name], [city]) VALUES (1, N'Crystal Ballroom', N'Portland')
INSERT [dbo].[venues] ([id], [name], [city]) VALUES (7, N'Wonder Ballroom', N'Portland')
INSERT [dbo].[venues] ([id], [name], [city]) VALUES (3, N'Pabst Theater', N'Milwaukee')
INSERT [dbo].[venues] ([id], [name], [city]) VALUES (4, N'Riverside Theater', N'Milwaukee')
SET IDENTITY_INSERT [dbo].[venues] OFF
