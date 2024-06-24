namespace Jostic.Rusia2018.Domain.Entity
{
    public class Country
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;
        public Group grupo = new Group();
        public Continent continente = new Continent();
        public Technical tecnico = new Technical();
    }
}