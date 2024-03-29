USE [HataTakip]
GO
/****** Object:  Table [dbo].[HataSorumlusu]    Script Date: 05/18/2006 10:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HataSorumlusu](
	[SORUMLUID] [int] NOT NULL,
	[HATAID] [int] NOT NULL
) ON [PRIMARY]

GO
USE [HataTakip]
GO
ALTER TABLE [dbo].[HataSorumlusu]  WITH CHECK ADD  CONSTRAINT [FK_HataSorumlusu_Hata] FOREIGN KEY([HATAID])
REFERENCES [dbo].[Hata] ([ID])
GO
ALTER TABLE [dbo].[HataSorumlusu]  WITH CHECK ADD  CONSTRAINT [FK_HataSorumlusu_Kullanici] FOREIGN KEY([SORUMLUID])
REFERENCES [dbo].[Kullanici] ([ID])