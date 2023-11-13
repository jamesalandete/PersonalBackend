

using System.ComponentModel.DataAnnotations;

namespace Data.Request
{
    public partial class Login
    {
        [Required(ErrorMessage = "El campo Usuario es requerido.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Pass es requerido.")]
        public string Pass { get; set; }
    }
}
