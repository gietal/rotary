using UnityEngine;
using System.Collections;

namespace Rotary
{
    public abstract class ISwitch : MonoBehaviour 
    {
        public ISwitchDelegate switchDelegate = null;
        public bool isSwitchActive { get; protected set; }

        public abstract bool ActivateSwitch(GameObject sender);

        public abstract bool DeactivateSwitch(GameObject sender);
    }

}