﻿namespace Jostic.Rusia2018.Domain.Entity
{
    public class Technical
    {
        public int idTecnico { get; set; }
        public string nomTecnico { get; set; } = string.Empty;
        public string nacionalidad { get; set; } = string.Empty;
        public DateTime fechaNacimiento { get; set; }
    }
}
