using System;
using System.Collections.Generic;

namespace crud.Models
{
    public partial class GenPersonas
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string CodigoIndentificacion { get; set; } = null!;
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        
    }
    public partial class GenPersonasView
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string CodigoIndentificacion { get; set; } = null!;
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string TipoIdentificacionNombre { get; set; }

    }

}
