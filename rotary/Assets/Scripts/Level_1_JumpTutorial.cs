using UnityEngine;
using System.Collections;

namespace Rotary
{

    public class Level_1_JumpTutorial : MonoBehaviour 
    {
        IEnumerator Start()
        {
            // try to grab uicontrol when it spawn
            while (TouchControl.Instance() == null)
            {
                yield return new WaitForFixedUpdate();
            }

            // disable some buttons
            var touchControl = TouchControl.Instance();
            touchControl.DisableUIButton("Jump");
            touchControl.DisableUIButton("Interact");
            touchControl.DisableUIButton("RotateRight");
            touchControl.DisableUIButton("RotateLeft");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                TouchControl.Instance().EnableUIButton("Jump");
            }
        }
    }
}
