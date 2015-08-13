/****** Object:  Table [dbo].[CompanyStatus]    Script Date: 08/13/2015 12:49:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompanyStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusTitle] [nvarchar](200) NOT NULL,
	[StatusDescription] [nvarchar](max) NULL,
	[SortOrder] [int] NOT NULL,
	[RecCreatedDate] [datetime] NOT NULL,
	[RecLastUpdatedDate] [datetime] NOT NULL,
	[RecCreatedBy] [nvarchar](128) NOT NULL,
	[RecLastUpdatedBy] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


