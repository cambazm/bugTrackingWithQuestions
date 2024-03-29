USE [HataTakip]
GO
/****** Object:  Table [dbo].[Proje]    Script Date: 05/18/2006 11:00:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ISIM] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[TUR] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
 CONSTRAINT [PK_Proje] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
