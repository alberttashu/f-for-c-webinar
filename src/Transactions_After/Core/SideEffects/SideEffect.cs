using System;
using Transactions_After.Core.Entities;

namespace Transactions_After.Core.SideEffects
{
    abstract class SideEffect<TEntity> where TEntity : Entity
    {
        public Guid EntityId { get; }
       
        protected SideEffect(Guid entityId)
        {
            EntityId = entityId;
        }

        public abstract void Apply(TEntity entity);
    }
}