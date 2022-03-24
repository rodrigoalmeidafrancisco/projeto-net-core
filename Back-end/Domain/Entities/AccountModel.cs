using Domain.Entities.Base;
using Flunt.Validations;

namespace Domain.Entities
{
    public class AccountModel : BaseEntity
    {
        public AccountModel()
        {

        }

        public AccountModel(string name, string email, bool emailConfirmed, string password, int accessFailedCount, 
            bool lockout, DateTime? lockoutEnd)
        {
            Name = name;
            Email = email;
            EmailConfirmed = emailConfirmed;
            Password = password;
            AccessFailedCount = accessFailedCount;
            Lockout = lockout;
            LockoutEnd = lockoutEnd;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string Password { get; private set; }
        public int AccessFailedCount { get; private set; }
        public bool Lockout { get; private set; }
        public DateTime? LockoutEnd { get; private set; }

        public override void ValidateEntity()
        {
            AddNotifications(new Contract<AccountModel>().Requires()
              .IsNotNull(Name, nameof(Name), "Nome é obrigatório.")
              .IsNotNullOrEmpty(Name, nameof(Name), "Nome é obrigatório.")
              .IsNotNullOrWhiteSpace(Name, nameof(Name), "Nome é obrigatório.")
              .IsLowerOrEqualsThan(Name, 500, nameof(Name), "Nome não deve ter mais de 500 caracteres.")
              .IsNotNull(Email, nameof(Email), "E-mail é obrigatório.")
              .IsNotNullOrEmpty(Email, nameof(Email), "E-mail é obrigatório.")
              .IsNotNullOrWhiteSpace(Email, nameof(Email), "E-mail é obrigatório.")
              .IsLowerOrEqualsThan(Email, 500, nameof(Email), "E-mail não deve ter mais de 500 caracteres.")
              .IsNotNull(Password, nameof(Password), "Senha é obrigatório.")
              .IsNotNullOrEmpty(Password, nameof(Password), "Senha é obrigatório.")
              .IsNotNullOrWhiteSpace(Password, nameof(Password), "Senha é obrigatório.")
           );
        }
    }
}
