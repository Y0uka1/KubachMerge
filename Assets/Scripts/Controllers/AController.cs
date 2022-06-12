using UnityEngine;
using Views;
using Zenject;

namespace Controllers
{
    public abstract class AController<TView>: IInitializable, IController where TView:AView
    {
        protected TView View;

        protected AController(TView view)
        {
            View = view;
        }

        public virtual void Initialize()
        {
        }
    }
}