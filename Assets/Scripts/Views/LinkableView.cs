using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Views
{
    public abstract class LinkableView:AView
    {
        protected GameEntity Entity;
        public virtual void Link(GameEntity entity)
        {
            gameObject.Link(entity);
            Entity = entity;
        }
    }
}