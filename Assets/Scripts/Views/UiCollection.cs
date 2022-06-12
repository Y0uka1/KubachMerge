using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public abstract class UiCollection<TView>:AView where TView: AView
    {
        [SerializeField] protected Transform Parent;
        [SerializeField] protected TView Prefab;
        
        public virtual TView Add()
        {
            return Instantiate(Prefab, Parent);
        }

        public virtual TView[] Get()
        {
            return Parent.GetComponentsInChildren<TView>();
        }

        public virtual int Count()
        {
            return Parent.GetComponentsInChildren<TView>().Length;
        }
    }
}