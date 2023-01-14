namespace crud.Models
{
    public class Login
    {
        public string Usuario { get; set; } = null!;

        public string Pass { get; set; } = null!;
    }

    public class LoginView
    {
        public int Id { get; set; } = 0!;
        public string Usuario { get; set; } = null!;

        public string Token { get; set; } = null!;
    }

    public class UsuarioToken
    {
        public int Id { get; set; } = 0!;
        public string Usuario { get; set; } = null!;

    }
}
