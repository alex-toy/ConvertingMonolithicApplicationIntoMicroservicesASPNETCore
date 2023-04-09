EXEC CREATE_ORDER @userId = 1, @userName = 'alex'
EXEC CREATE_ORDER @userId = 2, @userName = 'seb'
EXEC CREATE_ORDER @userId = 3, @userName = 'kate'

EXEC CREATE_ORDER_DETAILS @orderId = 1, @productId = 1, @quantity = 10, @productName = 'iphone'

EXEC UPDATE_INVENTORY @productId = 1, @quantity = 10





