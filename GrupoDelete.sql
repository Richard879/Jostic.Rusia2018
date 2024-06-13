CREATE PROCEDURE GrupoDelete
				 @idGrupo AS INT
AS
BEGIN
	DELETE FROM Grupo WHERE idGrupo = @idGrupo
END