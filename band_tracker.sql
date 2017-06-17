
USE [band_tracker]

GO

/****** Object:  Table [dbo].[bands]    Script Date: 6/17/2017 1:55:24 PM ******/

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

/****** Object:  Table [dbo].[bands_venues]    Script Date: 6/17/2017 1:55:24 PM ******/

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

/****** Object:  Table [dbo].[venues]    Script Date: 6/17/2017 1:55:24 PM ******/

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

SET IDENTITY_INSERT [dbo].[bands] ON 



INSERT [dbo].[bands] ([id], [name], [photo]) VALUES (1, N'Animal Collective', N'https://e.snmc.io/lk/l/a/8c5c20900586e04931242533ec47ddc1/2978480.jpg')

INSERT [dbo].[bands] ([id], [name], [photo]) VALUES (2, N'Future Islands', N'https://upload.wikimedia.org/wikipedia/commons/2/27/Future_islands_live.jpg')

INSERT [dbo].[bands] ([id], [name], [photo]) VALUES (3, N'Fleet Foxes', N'https://images-na.ssl-images-amazon.com/images/I/61Zalu-SFyL.jpg')

INSERT [dbo].[bands] ([id], [name], [photo]) VALUES (8, N'Joy Division', N'https://img.discogs.com/BItZIpj2YJ7q7_xtBhsIFNw1x90=/fit-in/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/A-3898-1100233174.jpg.jpg')

INSERT [dbo].[bands] ([id], [name], [photo]) VALUES (7, N'The Smiths', N'http://keyassets.timeincuk.net/inspirewp/live/wp-content/uploads/sites/28/2015/02/smithsnew250215.jpg')

SET IDENTITY_INSERT [dbo].[bands] OFF

SET IDENTITY_INSERT [dbo].[bands_venues] ON 



INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 2, 1)

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 1, 6)

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 7, 1)

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 2, 5)

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 3, 1)

SET IDENTITY_INSERT [dbo].[bands_venues] OFF

SET IDENTITY_INSERT [dbo].[venues] ON 



INSERT [dbo].[venues] ([id], [name], [city], [photo]) VALUES (1, N'Crystal Ballroom', N'Portland', N'http://www.crystalballroompdx.com/system/uploads/assets/Section%20Carousels/_v/MG-8978.jpg/header.jpg')

INSERT [dbo].[venues] ([id], [name], [city], [photo]) VALUES (5, N'Wonder Ballroom', N'Portland', N'http://thetraveljoint.com/wp-content/uploads/2016/02/wonderballroom.jpg')

INSERT [dbo].[venues] ([id], [name], [city], [photo]) VALUES (6, N'Pabst Theater', N'Milwaukee', N'http://www.milwaukee365.com/wp-content/uploads/sites/www.milwaukee365.com/images/venue/2767/pabst-theater-int.jpg')

SET IDENTITY_INSERT [dbo].[venues] OFF


