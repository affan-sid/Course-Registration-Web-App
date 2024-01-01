USE [Course Registration]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 12/5/2022 1:28:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[Id] [varchar](10) NOT NULL,
	[password] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 12/5/2022 1:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[id] [char](6) NOT NULL,
	[name] [char](30) NOT NULL,
	[credithours] [int] NOT NULL,
	[pre_requisite] [varchar](40) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [course_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REGISTRATION]    Script Date: 12/5/2022 1:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REGISTRATION](
	[stud_id] [char](8) NOT NULL,
	[course_id] [char](6) NOT NULL,
	[section] [varchar](10) NULL,
	[c_status] [varchar](10) NULL,
	[pre_requisite] [varchar](40) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [reg_pk] PRIMARY KEY CLUSTERED 
(
	[stud_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 12/5/2022 1:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[id] [char](8) NOT NULL,
	[fname] [char](50) NOT NULL,
	[depart] [varchar](4) NOT NULL,
	[student_batch] [varchar](5) NOT NULL,
	[current_sem] [varchar](2) NOT NULL,
	[gender] [char](10) NOT NULL,
	[email] [varchar](50) NULL,
	[contact_number] [char](15) NOT NULL,
	[section] [varchar](10) NULL,
	[cgpa] [varchar](1) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [student_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[course] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[course] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[REGISTRATION] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[REGISTRATION] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[student] ADD  DEFAULT ('1') FOR [current_sem]
GO
ALTER TABLE [dbo].[student] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[student] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[REGISTRATION]  WITH CHECK ADD  CONSTRAINT [reg_stud_fk] FOREIGN KEY([stud_id])
REFERENCES [dbo].[student] ([id])
GO
ALTER TABLE [dbo].[REGISTRATION] CHECK CONSTRAINT [reg_stud_fk]
GO
ALTER TABLE [dbo].[REGISTRATION]  WITH CHECK ADD  CONSTRAINT [reg_stud_fk2] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[REGISTRATION] CHECK CONSTRAINT [reg_stud_fk2]
GO
