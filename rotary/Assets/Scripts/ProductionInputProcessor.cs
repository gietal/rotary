using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Rotary
{

    public class ProductionInputProcessor : MonoBehaviour {

        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () 
        {
            var rotate = CrossPlatformInputManager.GetAxis("RotateWorld");

            if (rotate > float.Epsilon)
            {
                OrientationController.Instance().RotateRight();
            }
            else if (rotate < -float.Epsilon)
            {
                OrientationController.Instance().RotateLeft();
            }


        }
    }
}
