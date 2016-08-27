using UnityEngine;
using System.Collections;

namespace Rotary
{
    public class GateBehaviour : ISwitchDelegate
    {
        // ISwitchDelegates 

        public override void OnSwitchActivated(GameObject sender)
        {
            OpenGate();
        }

        public override void OnSwitchDeactivated(GameObject sender)
        {
            CloseGate();
        }

        // Gate Behaviours

        private float closedLength = 0;

        public float currentGateScale 
        {
            get
            {
                return transform.localScale.x;
            }

            private set
            {
                var scale = transform.localScale;
                scale.x = value;
                transform.localScale = scale;
            }
        }

        void Awake()
        {
            closedLength = transform.localScale.x;
        }

        private void OpenGate()
        {
            Debug.Log("opening gate: " + this.name);
            StopAllCoroutines();
            StartCoroutine(TweenGateMovementCoroutine(0));
        }

        private void CloseGate()
        {
            Debug.Log("closing gate: " + this.name);
            StopAllCoroutines();
            StartCoroutine(TweenGateMovementCoroutine(closedLength));
        }

        IEnumerator TweenGateMovementCoroutine(float target)
        {
            Debug.Log(this.name + " [Begin TweenGateMovement Coroutine]");
            bool opening = target < currentGateScale;

            float movementPerSecond = opening ? -2 : 2; // if gate is opening, we reduce the gate size
            float movementPerStep = movementPerSecond * Time.fixedDeltaTime;

            // loop
            if (opening)
            {
                while (target < currentGateScale)
                {
                    currentGateScale += movementPerStep;
                    yield return new WaitForFixedUpdate();
                }
            }
            else
            {
                while (target > currentGateScale)
                {
                    currentGateScale += movementPerStep;
                    yield return new WaitForFixedUpdate();
                } 
            }

            // done
            currentGateScale = target;
            Debug.Log(this.name + " [End TweenGateMovement Coroutine]");

            yield break;
        }
    }
}