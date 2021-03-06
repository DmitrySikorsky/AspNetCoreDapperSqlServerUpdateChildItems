USE [ChildItemsUpdate]
GO
/****** Object:  UserDefinedTableType [dbo].[ChildItemsType]    Script Date: 20.11.2018 12:41:07 ******/
CREATE TYPE [dbo].[ChildItemsType] AS TABLE(
	[Id] [int] NOT NULL,
	[ParentItemId] [int] NOT NULL,
	[SomeProperty1] [nvarchar](64) NOT NULL,
	[SomeProperty2] [nvarchar](64) NOT NULL,
	[SomeProperty3] [nvarchar](64) NOT NULL
)
GO
/****** Object:  Table [dbo].[ChildItems]    Script Date: 20.11.2018 12:41:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentItemId] [int] NOT NULL,
	[SomeProperty1] [nvarchar](64) NOT NULL,
	[SomeProperty2] [nvarchar](64) NOT NULL,
	[SomeProperty3] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Childs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParentItems]    Script Date: 20.11.2018 12:41:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SomeProperty1] [nvarchar](64) NOT NULL,
	[SomeProperty2] [nvarchar](64) NOT NULL,
	[SomeProperty3] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ParentItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChildItems]  WITH CHECK ADD  CONSTRAINT [FK_ChildItems_ParentItems] FOREIGN KEY([ParentItemId])
REFERENCES [dbo].[ParentItems] ([Id])
GO
ALTER TABLE [dbo].[ChildItems] CHECK CONSTRAINT [FK_ChildItems_ParentItems]
GO
/****** Object:  StoredProcedure [dbo].[UpdateChildItems]    Script Date: 20.11.2018 12:41:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateChildItems]
	@ParentItemId INT,
	@ChildItems ChildItemsType READONLY
AS
BEGIN
	MERGE ChildItems AS t
	USING (SELECT Id, ParentItemId, SomeProperty1, SomeProperty2, SomeProperty3 FROM @ChildItems) AS s
	ON t.Id = s.Id AND t.ParentItemId = s.ParentItemId
	WHEN MATCHED THEN
		UPDATE SET t.SomeProperty1 = s.SomeProperty1, t.SomeProperty2 = s.SomeProperty2, t.SomeProperty3 = s.SomeProperty3
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (ParentItemId, SomeProperty1, SomeProperty2, SomeProperty3) 
			VALUES (s.ParentItemId, s.SomeProperty1, s.SomeProperty2, s.SomeProperty3)
	WHEN NOT MATCHED BY SOURCE AND t.ParentItemId = @ParentItemId THEN
		DELETE;
END
GO