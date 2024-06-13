namespace Jostic.Rusia2018.Domain.Entity
{
    public class Pais
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;
        public Grupo grupo = new Grupo();
        public Continente continente = new Continente();
        public Tecnico tecnico = new Tecnico();
    }
}
