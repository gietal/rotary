using UnityEngine;
using System.Collections;

namespace Rotary
{
    public class GateBehaviour : ISwitchDelegate
    {
        // ISwitchDelegates 

        public override void OnSwitchActivated(GameObject sender)
        {
        }

        public override void OnSwitchDeactivated(GameObject sender)
        {
        }

        // Gate Behaviours

        private float closedLength = 0;

        void Awake()
        {
            closedLength = transform.localScale.x;
        }

        private void OpenGate()
        {
            Debug.Log("opening gate: " + this.name);
            var scale = transform.localScale;
            scale.x = 0;
            transform.localScale = scale;
        }

        private void CloseGate()
        {
            Debug.Log("closing gate: " + this.name);
            var scale = transform.localScale;
            scale.x = closedLength;
            transform.localScale = scale;
        }
    }
}