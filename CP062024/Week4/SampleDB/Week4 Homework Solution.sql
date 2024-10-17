-- Select the BikeStores database
USE BikeStores;

SELECT o.order_id, c.first_name, c.last_name,
CASE WHEN o.order_status = 1 THEN 'Ordered'
WHEN o.order_status = 2 THEN 'Shipped'
WHEN o.order_status = 3 THEN 'Out For Delivery'
WHEN o.order_status = 4 THEN 'Delivered'
END AS "order_status",  --case when builds a column on the fly to associate the numeric status with an understandable status
o.order_date
FROM sales.orders o --o is a table alias
--customer table is main customer table
-- all customers in customer table are identifed by the customer_id
--when we reference the customer_id column in order table
--we are then able to associate the order with a customer
--after referencing customer table with customer_id
--we can then access all other customer information
--from the customer table
JOIN sales.customers c --c is a table alias
ON o.customer_id = c.customer_id
ORDER BY o.order_id