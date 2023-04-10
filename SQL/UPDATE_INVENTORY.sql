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
	@name [varchar](50),
	@quantity int,
	@productId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	MERGE dbo.[Inventory] WITH (SERIALIZABLE) AS T
	USING (VALUES (@name, @quantity, @productId)) AS U ([Name], Quantity, ProductId)
	ON U.ProductId = T.ProductId

	WHEN MATCHED THEN 
		UPDATE SET T.Quantity = U.Quantity

	WHEN NOT MATCHED THEN
		INSERT ([Name], Quantity, ProductId)
		VALUES (@name, @quantity, @productId);

END

GO