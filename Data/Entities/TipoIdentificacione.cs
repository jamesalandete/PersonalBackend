namespace Data.Entities
{
    public partial class TipoIdentificacion
    {

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Sigla { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? Activo { get; set; }
    }
}
