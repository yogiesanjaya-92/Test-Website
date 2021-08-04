USE [TestData]
GO

/****** Object:  Table [dbo].[ImportedData]    Script Date: 8/4/2021 3:24:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ImportedData](
	[String ID] [uniqueidentifier] NOT NULL,
	[String Content] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ImportedData] ADD  CONSTRAINT [DF_ImportedData_String ID]  DEFAULT (newsequentialid()) FOR [String ID]
GO

