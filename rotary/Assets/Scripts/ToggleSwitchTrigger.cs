using UnityEngine;
using System.Collections;

namespace Rotary
{
    public class ToggleSwitchTrigger : MonoBehaviour 
    {
        private ToggleSwitchBehaviour switchBehaviour;

        void Awake()
        {
            switchBehaviour = GetComponentInParent<ToggleSwitchBehaviour>();
            Debug.AssertFormat(switchBehaviour != null, "toggle switch parent doesnt have ToggleSwitchBehaviour");
        }

        void OnTriggerStay2D(Collider2D other)
        {
            // toggle switch can only be manually toggled by player
            if (other.tag != "Player")
                return;

            // only do it if it's the player's trigger
            // not the actual collider
            if (!other.isTrigger)
                return;
            
            // only toggle if user pressed interact key
            if (Input.GetKeyDown(KeyCode.F))
            {
                switchBehaviour.ToggleSwitch();
            }
        }
    }
}