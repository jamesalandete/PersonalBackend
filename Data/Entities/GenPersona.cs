
namespace Data.Entities
{
    public partial class GenPersona
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public bool? Activo { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; } = null!;
    }
}
