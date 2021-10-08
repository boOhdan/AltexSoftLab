USE Northwind

-- 4. Клієнти з регіону SP або міста Portland

SELECT * FROM Customers c
WHERE c.City = 'Portland'

UNION

SELECT * FROM Customers c
WHERE c.Region = 'SP'

-- 5. Клієнти з регіону SP окрім тих хто проживає в Sao Paulo

SELECT * FROM Customers c
WHERE c.Region = 'SP'

EXCEPT

SELECT * FROM Customers c
WHERE c.City = 'Sao Paulo'

-- 6. Кількість постачальників по регіону

SELECT Country, Region, COUNT(*) 
FROM Suppliers s
WHERE Region IS NOT NULL
GROUP BY Country, Region
HAVING COUNT(*) > 1