using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuarios : Entity
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
