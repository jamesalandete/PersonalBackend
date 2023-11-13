using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Request
{
    public partial class PersonaRequest
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Activo { get; set; }
    }
}
