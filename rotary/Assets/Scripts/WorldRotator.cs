using UnityEngine;
using System.Collections;

namespace Rotary
{
    
    public class WorldRotator : MonoBehaviour, IOrientationChangedSubscriber {

        void OnEnable() 
        {
            OrientationController.Instance().Subscribe(this);
        }

        void OnDisable()
        {
            OrientationController.Instance().UnSubscribe(this);
        }
            
        public void OnOrientationChanged(Vector2 newUp, Vector2 newRight, float rotationAngle)
        {
            // find player
            var player = GameObject.FindGameObjectWithTag("Player");

            // rotate around player's position around z axis
            transform.RotateAround(player.transform.position, Vector3.forward, rotationAngle);
        }
    }
}
