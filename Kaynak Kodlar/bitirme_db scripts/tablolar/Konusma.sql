USE [HataTakip]
GO
/****** Object:  Table [dbo].[Konusma]    Script Date: 05/18/2006 10:58:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Konusma](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HATAID] [int] NOT NULL,
	[YOLLAYANID] [int] NOT NULL,
	[MESAJ] [nvarchar](max) COLLATE Turkish_CI_AS NOT NULL,
	[ZAMAN] [datetime] NOT NULL,
 CONSTRAINT [PK_Konusma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [HataTakip]
GO
ALTER TABLE [dbo].[Konusma]  WITH CHECK ADD  CONSTRAINT [FK_Konusma_Hata] FOREIGN KEY([HATAID])
REFERENCES [dbo].[Hata] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Konusma]  WITH CHECK ADD  CONSTRAINT [FK_Konusma_Kullanici] FOREIGN KEY([YOLLAYANID])
REFERENCES [dbo].[Kullanici] ([ID])