using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

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

        void OnTriggerEnter2D(Collider2D other)
        {
            // turn on the interact button
            #if UNITY_ANDROID || UNITY_IOS || MOBILE_INPUT

            // toggle switch can only be manually toggled by player
            if (other.tag != "Player")
                return;

            // only do it if it's the player's trigger
            // not the actual collider
            if (!other.isTrigger)
                return;

            TouchControl.Instance().EnableUIButton("Interact");

            #endif
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // turn on the interact button
            #if UNITY_ANDROID || UNITY_IOS || MOBILE_INPUT

            // toggle switch can only be manually toggled by player
            if (other.tag != "Player")
                return;

            // only do it if it's the player's trigger
            // not the actual collider
            if (!other.isTrigger)
                return;

            TouchControl.Instance().DisableUIButton("Interact");

            #endif
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
            if (CrossPlatformInputManager.GetButtonDown("Interact"))
            {
                switchBehaviour.ToggleSwitch();
            }
        }
    }
}