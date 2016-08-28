using UnityEngine;
using System.Collections;

namespace Rotary
{

    public class Level_2_RotateTutoriala : MonoBehaviour, IOrientationChangedSubscriber
    {
        private bool isDone = false;

        IEnumerator Start()
        {
            // try to grab uicontrol when it spawn
            while (TouchControl.Instance() == null)
            {
                yield return new WaitForFixedUpdate();
            }

            // disable some buttons
            var touchControl = TouchControl.Instance();
            touchControl.DisableUIButton("RotateRight");
            touchControl.DisableUIButton("RotateLeft");

            OrientationController.Instance().Subscribe(this);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (isDone)
                return;
            
            if (other.tag == "Player")
            {
                TouchControl.Instance().EnableUIButton("RotateRight");
            }
        }

        public void OnOrientationChanged(float newAngle)
        {
            if (isDone)
                return;
            
            // rotated once, so disable
            TouchControl.Instance().DisableUIButton("RotateRight");
            this.enabled = false;
            isDone = true;
            OrientationController.Instance().UnSubscribe(this);
        }
    }
}
