using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public partial class AuthUser
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        [NotMapped]
        public string Pass { get; set; } = null!;
        [NotMapped]
        public DateTime? AddedOn { get; set; }
        [NotMapped]
        public DateTime? ModifiedOn { get; set; }
    }
}
