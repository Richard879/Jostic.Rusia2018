CREATE PROCEDURE GrupoInsert
				@descripcion AS CHAR(1)
AS
BEGIN
		INSERT INTO Grupo(descripcion)
				VALUES(@descripcion)
END