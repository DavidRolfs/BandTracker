USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 6/17/2017 1:56:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[photo] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 6/17/2017 1:56:30 PM ******/
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
/****** Object:  Table [dbo].[venues]    Script Date: 6/17/2017 1:56:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[photo] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 4, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 5, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 6, 7)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 7, 8)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 13, 11)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 14, 13)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 15, 17)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (16, 31, 37)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (17, 32, 39)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (18, 33, 43)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (19, 34, 44)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 16, 18)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (11, 22, 21)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (12, 23, 23)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (13, 24, 27)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (14, 25, 28)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
