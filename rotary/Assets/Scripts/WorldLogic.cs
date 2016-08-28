using UnityEngine;
using System.Collections;

namespace Rotary
{
    
    public class WorldLogic : MonoBehaviour, IOrientationChangedSubscriber {

        void Start()
        {
            ParentAllObjects();
        }

        void OnEnable() 
        {
            OrientationController.Instance().Subscribe(this);
        }

        void OnDisable()
        {
            OrientationController.Instance().UnSubscribe(this);
        }
            
        public void OnOrientationChanged(float newAngle)
        {
            // find player
            var player = GameObject.FindGameObjectWithTag("Player");

            // rotate around player's position around z axis

            // rotate the difference of angle
            var diff = newAngle - transform.rotation.eulerAngles.z ;
            transform.RotateAround(player.transform.position, Vector3.forward, diff);
        }

        void ParentAllObjects()
        {
            var uiLayer = LayerMask.NameToLayer("UI");

            // parent all objects in the scene to me
            var transforms = GameObject.FindObjectsOfType<Transform>();
            foreach (var t in transforms)
            {
                // only deal with top level objects
                if (t.parent != null)
                    continue;

                // skip cameras and player etc
                if (t.tag == "MainCamera" || t.tag == "Player" || t.gameObject.layer == uiLayer)
                    continue;

                // parent all top level objects to the world hinge
                t.parent = this.transform;
            }
        }
    }
}
