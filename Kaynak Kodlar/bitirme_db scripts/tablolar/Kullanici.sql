USE [HataTakip]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 05/18/2006 10:59:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIPID] [int] NOT NULL,
	[BILGOZELLIK] [nvarchar](max) COLLATE Turkish_CI_AS NULL,
	[ISIM] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL CONSTRAINT [DF_Kullanici_ISIM]  DEFAULT (N'varsayılan'),
	[SIFRE] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL CONSTRAINT [DF_Kullanici_SIFRE]  DEFAULT ((123)),
	[MAIL] [nvarchar](40) COLLATE Turkish_CI_AS NOT NULL CONSTRAINT [DF_Kullanici_MAIL]  DEFAULT (N'yok@hatatakip.com'),
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [HataTakip]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_KTip] FOREIGN KEY([TIPID])
REFERENCES [dbo].[KTip] ([ID])
ON UPDATE CASCADE