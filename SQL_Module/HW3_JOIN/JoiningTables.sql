USE Northwind;

-- 1.

SELECT * FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products)

-- 2.

SELECT C.CategoryName, MAX(P.UnitPrice) FROM Products AS P
JOIN Categories AS C ON C.CategoryID = P.CategoryID
GROUP BY C.CategoryName

-- 3.

SELECT E.FirstName, E.LastName, T.TerritoryDescription, R.RegionDescription
FROM EmployeeTerritories AS ET
JOIN Territories AS T ON T.TerritoryID = ET.TerritoryID
JOIN Region AS R ON R.RegionID = T.RegionID
JOIN Employees AS E ON E.EmployeeID = ET.EmployeeID

-- 4. 

INSERT INTO Region
VALUES (5, 'RegionWithNoEmployers1'), (6, 'RegionWithNoEmployers2');

INSERT INTO Territories
VALUES 
(98112, 'TerritoryWithNoEmployers1', 5),
(98233, 'TerritoryWithNoEmployers2', 5),
(99788, 'TerritoryWithNoEmployers3', 5),
(101404, 'TerritoryWithNoEmployers4' , 6),
(101506, 'TerritoryWithNoEmployers5' , 6),
(102392, 'TerritoryWithNoEmployers6' , 6);

-- First option

SELECT R.RegionDescription
FROM Region AS R 

EXCEPT

SELECT DISTINCT R.RegionDescription
FROM EmployeeTerritories AS ET
JOIN Territories AS T ON T.TerritoryID = ET.TerritoryID
JOIN Region AS R ON R.RegionID = T.RegionID

-- Second option

SELECT DISTINCT R.RegionDescription
FROM Region AS R 
Where R.RegionID NOT IN 
(
	SELECT R.RegionID
	FROM EmployeeTerritories AS ET
	JOIN Territories AS T ON T.TerritoryID = ET.TerritoryID
	JOIN Region AS R ON R.RegionID = T.RegionID
)