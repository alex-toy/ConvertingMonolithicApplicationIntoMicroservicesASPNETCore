/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/28/2020 10:45:21 AM ******/
USE [Order]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductName] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [Order]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 12/28/2020 10:45:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UpdatedTime] [datetime] NOT NULL,
	[UserName] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



USE [Order]
GO

/****** Object:  StoredProcedure [dbo].[CREATE_ORDER]    Script Date: 12/28/2020 10:48:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_ORDER]
	-- Add the parameters for the stored procedure here
	@userId int, 
	@userName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Order] VALUES (@userId, GETDATE(), @userName)

	SELECT @@IDENTITY
END

GO


USE [Order]
GO

/****** Object:  StoredProcedure [dbo].[CREATE_ORDER_DETAILS]    Script Date: 12/28/2020 10:48:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_ORDER_DETAILS]
	-- Add the parameters for the stored procedure here
	@orderId int, 
	@productId int,
	@quantity int,
	@productName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[OrderDetail]
	([OrderId],[ProductId],[Quantity],[ProductName]) VALUES (@orderId, @productId, @quantity, @productName)

END

GO

