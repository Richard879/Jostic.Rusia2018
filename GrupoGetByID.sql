CREATE PROCEDURE GrupoGetByID
				@idGrupo AS INT
AS
BEGIN

    SELECT	idGrupo
			,descripcion
    FROM	Grupo
    WHERE	idGrupo=@idGrupo

END