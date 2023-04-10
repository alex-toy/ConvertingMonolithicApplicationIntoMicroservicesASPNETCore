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