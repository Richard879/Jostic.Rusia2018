CREATE PROCEDURE GrupoListWithPagination
(
    @PageNumber int,
    @PageSize int
)
AS
BEGIN

    SELECT	idGrupo
			,descripcion
    FROM	Grupo
    ORDER BY idGrupo
    OFFSET (@PageNumber-1)*@PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY
END