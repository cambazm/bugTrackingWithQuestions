USE [HataTakip]
GO
/****** Object:  Table [dbo].[ProjeSorumlusu]    Script Date: 05/18/2006 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjeSorumlusu](
	[PROJEID] [int] NOT NULL,
	[SORUMLUID] [int] NOT NULL
) ON [PRIMARY]

GO
USE [HataTakip]
GO
ALTER TABLE [dbo].[ProjeSorumlusu]  WITH CHECK ADD  CONSTRAINT [FK_ProjeSorumlusu_Kullanici] FOREIGN KEY([SORUMLUID])
REFERENCES [dbo].[Kullanici] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ProjeSorumlusu]  WITH CHECK ADD  CONSTRAINT [FK_ProjeSorumlusu_Proje] FOREIGN KEY([PROJEID])
REFERENCES [dbo].[Proje] ([ID])
ON UPDATE CASCADE