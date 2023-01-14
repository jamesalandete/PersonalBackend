using System;
using System.Collections.Generic;

namespace crud.Models
{
    public partial class ConfigUsuario
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Pass { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Estado { get; set; }

    }
}
