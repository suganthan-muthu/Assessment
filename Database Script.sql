USE [MailDIR]
GO
/****** Object:  Table [dbo].[tblMailDetails]    Script Date: 1/10/2021 9:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMailDetails](
	[Id] [int] NOT NULL,
	[MailItemsId] [int] NOT NULL,
	[Message_ID] [varchar](max) NULL,
	[Date] [varchar](max) NULL,
	[From] [varchar](max) NULL,
	[To] [varchar](max) NULL,
	[cc] [varchar](max) NULL,
	[Bcc] [varchar](max) NULL,
	[Subject] [varchar](max) NULL,
	[Mime_Version] [varchar](max) NULL,
	[Content_Type] [varchar](max) NULL,
	[Content_Transfer_Encoding] [varchar](max) NULL,
	[X_From] [varchar](max) NULL,
	[X_To] [varchar](max) NULL,
	[X_cc] [varchar](max) NULL,
	[X_bcc] [varchar](max) NULL,
	[X_Folder] [varchar](max) NULL,
	[X_Origin] [varchar](max) NULL,
	[X_FileName] [varchar](max) NULL,
	[MailMessage] [varchar](max) NULL,
 CONSTRAINT [PK_MailDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMailDetailsColMap]    Script Date: 1/10/2021 9:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMailDetailsColMap](
	[DbColumnName] [varchar](200) NOT NULL,
	[FlatFileColumnName] [varchar](200) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMailItems]    Script Date: 1/10/2021 9:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMailItems](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [varbinary](300) NULL,
 CONSTRAINT [PK_MailItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 1/10/2021 9:42:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varbinary](300) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblMailDetails]  WITH CHECK ADD  CONSTRAINT [FK_MailDetails_MailItems] FOREIGN KEY([MailItemsId])
REFERENCES [dbo].[tblMailItems] ([Id])
GO
ALTER TABLE [dbo].[tblMailDetails] CHECK CONSTRAINT [FK_MailDetails_MailItems]
GO
ALTER TABLE [dbo].[tblMailItems]  WITH CHECK ADD  CONSTRAINT [FK_MailItems_tblUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUsers] ([Id])
GO
ALTER TABLE [dbo].[tblMailItems] CHECK CONSTRAINT [FK_MailItems_tblUsers]
GO
