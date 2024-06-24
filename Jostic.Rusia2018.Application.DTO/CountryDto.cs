namespace Jostic.Rusia2018.Application.DTO
{
    public class CountryDto
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;
        public virtual GroupDto grupo { get; set; } = null!;
        public virtual ContinentDto continente { get; set; } = null!;
        public virtual TechnicalDto tecnico { get; set; } = null!;

        /*public int idGrupo { get; set; }
        public string descripcion { get; set; } = string.Empty;
        
        public int idContinente { get; set; }

        public string nomContinente { get; set; } = string.Empty;

        public int idTecnico { get; set; }

        public string nomTecnico { get; set; } = string.Empty;*/
    }
}