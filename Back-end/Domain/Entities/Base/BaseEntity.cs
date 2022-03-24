using Flunt.Notifications;

namespace Domain.Entities.Base
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public abstract void ValidateEntity();
    }
}
