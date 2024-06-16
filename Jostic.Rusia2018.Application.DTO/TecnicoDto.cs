using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jostic.Rusia2018.Application.DTO
{
    public class TecnicoDto
    {
        public int idTecnico { get; set; }
        public string nomTecnico { get; set; } = string.Empty;
        public string nacionalidad { get; set; } = string.Empty;
        public DateTime fechaNacimiento { get; set; }
    }
}
