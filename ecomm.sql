/****** Object:  Table [dbo].[Product]    Script Date: 12/28/2020 10:45:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Type] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_PADDING OFF
GO


USE [ECOMM]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 12/28/2020 10:45:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]

GO


SET ANSI_PADDING OFF
GO

USE [ECOMM]
GO

/****** Object:  StoredProcedure [dbo].[UPDATE_INVENTORY]    Script Date: 12/28/2020 10:48:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_INVENTORY]
	-- Add the parameters for the stored procedure here
	@productId int, 
	@quantity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Inventory] SET [Quantity] = @quantity WHERE [ProductId] = @productId

END

GO


USE [ECOMM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ADD_PRODUCT]
	@name varchar(50),
	@description varchar(1000),
	@type varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Product]
	([Name],[Description],[Type]) VALUES (@name, @description, @type)

END

GO