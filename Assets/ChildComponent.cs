using System;
using UnityEngine;

namespace Qazi.Modules.AI
{
    public class ChildComponent:MonoBehaviour
    {
        public void Register(Character parent)
        {
            parent.children.Add(this);
        }

    }
}