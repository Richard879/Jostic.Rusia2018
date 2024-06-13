CREATE PROCEDURE PaisList
AS
BEGIN
	SELECT		p.idPais
				,p.nomPais
	FROM		Pais AS p
END