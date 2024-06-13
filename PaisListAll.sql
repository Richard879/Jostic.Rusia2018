ALTER PROCEDURE PaisListAll
AS
BEGIN
	SELECT		p.idPais
				,p.nomPais
				,g.idGrupo
				,g.descripcion
				,c.idContinente
				,c.descripcion
				,t.idTecnico
				,t.nomTecnico
				,t.nacionalidad
				,t.fechaNacimiento
	FROM		Pais AS p
	INNER JOIN	Grupo		AS g ON p.idGrupo = g.idGrupo
	INNER JOIN	Continente  AS c ON p.idContinente = c.idContinente
	INNER JOIN	Tecnico		AS t ON t.idTecnico = p.idTecnico
END