USE Northwind

-- 4. �볺��� � ������ SP ��� ���� Portland

SELECT * FROM Customers c
WHERE c.City = 'Portland'

UNION

SELECT * FROM Customers c
WHERE c.Region = 'SP'

-- 5. �볺��� � ������ SP ���� ��� ��� ������� � Sao Paulo

SELECT * FROM Customers c
WHERE c.Region = 'SP'

EXCEPT

SELECT * FROM Customers c
WHERE c.City = 'Sao Paulo'

-- 6. ʳ������ ������������� �� ������

SELECT Country, Region, COUNT(*) 
FROM Suppliers s
WHERE Region IS NOT NULL
GROUP BY Country, Region
HAVING COUNT(*) > 1