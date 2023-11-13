using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Response
{
    public partial class UserResponse
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
