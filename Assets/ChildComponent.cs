using UnityEngine;

namespace Qazi.Modules.AI
{
    public class ChildComponent:MonoBehaviour
    {
        protected ChildComponent() { }
        public void Register(Character parent)
        {
            parent.children.Add(this);
        }
    }
}