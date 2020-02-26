using System;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entity
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}