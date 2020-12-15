using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qazi.Modules.AI
{
    public class Character : MonoBehaviour,RootComponent
    {
        public List<ChildComponent> children = new List<ChildComponent>();

        public void RegisterChildren()
        {
            foreach (ChildComponent c in GetComponentsInChildren<ChildComponent>())
            {
                c.Register(this);
            }
        }

        private void Awake()
        {
            RegisterChildren();
        }
    }

}