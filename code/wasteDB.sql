USE [wasteDB]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[mname] [varchar](50) NULL,
	[hname] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
	[total_worker] [varchar](50) NULL,
	[address] [varchar](500) NULL,
	[emailid] [varchar](50) NULL,
 CONSTRAINT [PK_Vendor1] PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[registration]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[registration](
	[userID] [varchar](50) NULL,
	[emailID] [varchar](50) NULL,
	[fname] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[father_Name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[dob] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[postal_Code] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[phone_no] [varchar](50) NULL,
	[rdate] [varchar](50) NULL,
	[image] [varchar](50) NULL,
	[utype] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[aadhar] [varchar](50) NULL,
	[fimg] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[pid] [varchar](50) NULL,
	[pspl] [varchar](50) NULL,
	[pname] [varchar](50) NULL,
	[pdesc] [varchar](max) NULL,
	[pimage] [varchar](50) NULL,
	[pdate] [varchar](50) NULL,
	[price] [varchar](50) NULL,
	[userrat] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[emailid] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[utype] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[category_details]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[category_details](
	[cid] [int] NULL,
	[cat_name] [varchar](150) NOT NULL,
	[cname] [varchar](50) NULL,
 CONSTRAINT [PK_category_details] PRIMARY KEY CLUSTERED 
(
	[cat_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bot_replay]    Script Date: 01/24/2020 11:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bot_replay](
	[msg] [varchar](50) NULL,
	[rbot] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
