CREATE PROCEDURE GrupoUpdate
				 @idGrupo AS INT
				 ,@descripcion AS CHAR(1)
AS
BEGIN
	UPDATE Grupo
	SET descripcion = @descripcion
	WHERE idGrupo = @idGrupo
END