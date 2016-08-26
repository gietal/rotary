using UnityEngine;
using System.Collections.Generic;

namespace Rotary
{
    public class ButtonSwitchTrigger : MonoBehaviour
    {
        private ISwitch switchBehaviour;
        private Dictionary<int, Collider2D> objectStayed;
        private bool isTriggered = false;

        void Awake()
        {
            switchBehaviour = GetComponentInParent<ISwitch>();
            Debug.AssertFormat(switchBehaviour != null, "button switch parent doesnt have ButtonSwitchBehaviour");

            objectStayed = new Dictionary<int, Collider2D>();
        }

        void Start()
        {
            objectStayed.Clear();
            isTriggered = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Wall")
                return;
            
            // put this on our list of things that stayed
            objectStayed.Add(other.GetHashCode(), other);

            // only activate if it's the first object 
            if(objectStayed.Count == 1)
                switchBehaviour.ActivateSwitch(this.gameObject);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // remove from our list
            objectStayed.Remove(other.GetHashCode());

            // if no objects on this button, deactivate
            if (objectStayed.Count == 0)
                switchBehaviour.DeactivateSwitch(this.gameObject);
        }
    }
}