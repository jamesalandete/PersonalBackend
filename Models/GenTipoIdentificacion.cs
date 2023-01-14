using System;
using System.Collections.Generic;

namespace crud.Models
{
    public partial class GenTipoIdentificacion
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int? Estado { get; set; }
    }
}
