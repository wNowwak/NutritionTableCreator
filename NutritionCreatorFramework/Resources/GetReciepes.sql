SELECT DISTINCT pr.Produkt_Nazwa AS Name, pr.Produkt_Id AS Id FROM Receptury rc
JOIN Produkty pr ON rc.Produkt_Id = pr.Produkt_Id 
ORDER BY pr.Produkt_Nazwa
