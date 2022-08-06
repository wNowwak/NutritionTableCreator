INSERT INTO Receptury (Produkt_Id, Skladnik_Id, Ilosc, Jednostka_Id, Ilosc_Gotowa, JednostkaGotowa_Id)
	VALUES(@PRODUCT_ID, (SELECT TOP 1 Skladnik_Id FROM Skladniki WHERE Skaldnik_Nazwa = @SKLADNIK_NAZWA), 
	@COMPONENT_QUANTITY, @UNIT_ID, @TOTAL_MASS, @TOTAL_UNIT_ID)