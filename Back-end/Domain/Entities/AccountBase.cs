using Domain.Entities.Base;
using Flunt.Validations;

namespace Domain.Entities
{
    public class AccountBase : BaseEntity
    {
        public AccountBase()
        {

        }

        public AccountBase(string email, bool emailConfirmed, string password, int accessFailedCount, 
            bool lockout, DateTime? lockoutEnd)
        {
            Email = email;
            EmailConfirmed = emailConfirmed;
            Password = password;
            AccessFailedCount = accessFailedCount;
            Lockout = lockout;
            LockoutEnd = lockoutEnd;

            ValidateEntity();
        }

        public string Email { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string Password { get; private set; }
        public int AccessFailedCount { get; private set; }
        public bool Lockout { get; private set; }
        public DateTime? LockoutEnd { get; private set; }

        public override void ValidateEntity()
        {
            AddNotifications(new Contract<AccountBase>().Requires()
              .IsNotNull(Email, nameof(Email), "E-mail é obrigatório.")
              .IsNotNullOrEmpty(Email, nameof(Email), "E-mail é obrigatório.")
              .IsNotNullOrWhiteSpace(Email, nameof(Email), "E-mail é obrigatório.")
              .IsLowerOrEqualsThan(Email, 200, nameof(Email), "E-mail não deve ter mais de 200 caracteres.")
              .IsNotNull(Password, nameof(Password), "Senha é obrigatório.")
              .IsNotNullOrEmpty(Password, nameof(Password), "Senha é obrigatório.")
              .IsNotNullOrWhiteSpace(Password, nameof(Password), "Senha é obrigatório.")
           );
        }
    }
}
