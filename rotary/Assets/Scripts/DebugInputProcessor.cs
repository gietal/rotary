using UnityEngine;
using System.Collections;

namespace Rotary
{
        
    public class DebugInputProcessor : MonoBehaviour {

    	// Use this for initialization
    	void Start () {
    	
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OrientationController.Instance().RotateLeft();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                OrientationController.Instance().RotateRight();
            }
    	}
    }
}
