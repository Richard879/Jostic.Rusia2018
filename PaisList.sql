CREATE PROCEDURE PaisList
AS
BEGIN
	SELECT		p.idPais
				,p.nomPais
				,g.idGrupo
				,g.descripcion
	FROM		Pais AS p
	INNER JOIN	Grupo AS g ON p.idGrupo = g.idGrupo
END