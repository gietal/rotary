using UnityEngine;
using System.Collections;

namespace Rotary
{

    public class Level_2_RotateTutorialb : MonoBehaviour, IOrientationChangedSubscriber
    {
        // major hack
       
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


        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (isDone)
                return;

            if (other.tag == "Player")
            {
                TouchControl.Instance().EnableUIButton("RotateLeft");

                OrientationController.Instance().Subscribe(this);
            }
        }

        public void OnOrientationChanged(float newAngle)
        {
            if (isDone)
                return;

            // rotated once, so enable both
            TouchControl.Instance().EnableUIButton("RotateRight");
            //TouchControl.Instance().EnableUIButton("RotateLeft");
            this.enabled = false;
            isDone = true;
            OrientationController.Instance().UnSubscribe(this);
        }
    }
}
