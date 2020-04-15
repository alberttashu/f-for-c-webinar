using System;

namespace Transactions_After.Core.Entities
{
    public class Entity
    {
        public Guid Id { get; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
