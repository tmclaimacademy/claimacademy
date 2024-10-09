USE BikeStores;

--SELECT (List) all the data in all the columns (*) 
--FROM (source table) (the) production.brands (table)
--ORDER BY (sort by) (the) brand_id
--SELECT *
--FROM production.brands
--ORDER BY brand_id;

SELECT *
FROM production.categories
ORDER BY category_id;

--List all the products in the products table, referencing the
--brand name and category name by their respective ids.
SELECT p.product_id, p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price
FROM production.products p
INNER JOIN production.brands b
ON p.brand_id = b.brand_id
INNER JOIN production.categories c
ON c.category_id = p.category_id
ORDER BY p.product_id;

SELECT *
FROM production.stocks
ORDER BY store_id, product_id;

SELECT *
FROM sales.customers
ORDER BY customer_id;

SELECT *
FROM sales.order_items
ORDER BY order_id, item_id;

--Get the total of each order
SELECT o.order_id, SUM(p.list_price) AS Total
FROM sales.orders o
INNER JOIN sales.order_items oi
ON o.order_id = oi.order_id
INNER JOIN production.products p
ON oi.product_id = p.product_id
GROUP BY o.order_id
ORDER BY order_id;

SELECT *
FROM sales.staffs
ORDER BY staff_id;

SELECT *
FROM sales.stores
ORDER BY store_id;

--Where does each employee work?
SELECT s1.first_name, s1.last_name, s1.email, s1.phone, 
CASE WHEN s1.active = 1 THEN 'Yes' ELSE 'No' END AS Active, --Show Yes if active, no if not 
s2.store_name AS 'Works At', CONCAT(s2.street, ', ', s2.city, ', ', s2.state, ' ', s2.zip_code) AS 'Store Address'
FROM sales.staffs s1
INNER JOIN sales.stores s2
ON s1.store_id = s2.store_id
ORDER BY s1.staff_id