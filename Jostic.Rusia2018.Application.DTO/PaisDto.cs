namespace Jostic.Rusia2018.Application.DTO
{
    public class PaisDto
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;

        public GrupoDto grupo = new GrupoDto();
    }
}
