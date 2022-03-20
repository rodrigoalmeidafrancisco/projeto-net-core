using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Account
{
    public class LoginCommand
    {
        [Required(ErrorMessage = "Usuário é obrigatório.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string Password { get; set; }
    }
}
