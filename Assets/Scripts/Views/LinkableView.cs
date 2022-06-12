using Entitas;
using Entitas.Unity;

namespace Views
{
    public abstract class LinkableView<TEntity> : AView where TEntity : IEntity
    {
        protected TEntity Entity;

        public virtual void Link(TEntity entity)
        {
            gameObject.Link(entity);
            Entity = entity;
        }
    }
}