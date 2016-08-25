using UnityEngine;
using System.Collections;

namespace Rotary
{
    public abstract class ISwitchDelegate : MonoBehaviour 
    {
        public abstract void OnSwitchActivated(GameObject sender);

        public abstract void OnSwitchDeactivated(GameObject sender);
    }
}