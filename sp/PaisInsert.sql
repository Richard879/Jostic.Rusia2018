CREATE PROCEDURE PaisInsert
				@nomPais		AS VARCHAR(50)
				,@idTecnico		AS INT
				,@idGrupo		AS INT
				,@idContinente	AS INT
AS
BEGIN
	INSERT INTO Pais (nomPais, idTecnico, idGrupo, idContinente)
			VALUES (@nomPais, @idTecnico, @idGrupo, @idContinente);
END