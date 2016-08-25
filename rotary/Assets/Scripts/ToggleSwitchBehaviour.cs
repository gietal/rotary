using UnityEngine;
using System.Collections;

namespace Rotary
{
    public class ToggleSwitchBehaviour : ISwitch 
    {
        public override bool ActivateSwitch(GameObject sender)
        {
            sprite.color = onColor;
            isSwitchActive = true;
            if (switchDelegate != null)
            {
                switchDelegate.OnSwitchActivated(this.gameObject);
            }
            return true;
        }

        public override bool DeactivateSwitch(GameObject sender)
        {
            sprite.color = offColor;
            isSwitchActive = false;
            if (switchDelegate != null)
            {
                switchDelegate.OnSwitchDeactivated(this.gameObject);
            }
            return true;
        }

        public bool ToggleSwitch()
        {
            return isSwitchActive ? DeactivateSwitch(this.gameObject) : ActivateSwitch(this.gameObject);
        }

        private Color onColor = Color.green;
        private Color offColor = Color.red;
        private SpriteRenderer sprite;

        void Awake()
        {
            sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}