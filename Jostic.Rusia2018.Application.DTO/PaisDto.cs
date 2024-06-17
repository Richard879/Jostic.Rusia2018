namespace Jostic.Rusia2018.Application.DTO
{
    public class PaisDto
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;
        public virtual GrupoDto grupo { get; set; } = null!;
        public virtual ContinenteDto continente { get; set; } = null!;
        public virtual TecnicoDto tecnico { get; set; } = null!;

        /*public int idGrupo { get; set; }
        public string descripcion { get; set; } = string.Empty;
        
        public int idContinente { get; set; }

        public string nomContinente { get; set; } = string.Empty;

        public int idTecnico { get; set; }

        public string nomTecnico { get; set; } = string.Empty;*/
    }
}