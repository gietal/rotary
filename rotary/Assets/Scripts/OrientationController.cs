using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rotary
{
    
    public class OrientationController 
    {

        private static OrientationController instance = new OrientationController();

        private List<IOrientationChangedSubscriber> subscribers = new List<IOrientationChangedSubscriber>();
        private float gravityForce = 1;

        public static OrientationController Instance()
        {
            return instance;
        }

        private OrientationController()
        {
            gravityForce = Physics2D.gravity.magnitude;
        }

        public void RotateRight()
        {
            Rotate(90);
        }

        public void RotateLeft()
        {
            Rotate(-90);
        }

        void Rotate(int angle)
        {
            // change camera here since it will be cheaper than in the camera
            var q = Quaternion.AngleAxis(angle, Vector3.forward);
            Camera.main.transform.rotation *= q;

            // get the new values
            Vector2 newUp = Camera.main.transform.up;
            Vector2 newRight = Camera.main.transform.right;

            // change gravity
            var newGravity = -newUp * gravityForce;
            Debug.Log("new gravity: " + newGravity);
            Physics2D.gravity = newGravity;

            // notify subscribers, they will handle themselves
            subscribers.ForEach(
                (subscriber) =>
                {
                    subscriber.OnOrientationChanged(newUp, newRight);
                }
            );
        }

        public void Subscribe(IOrientationChangedSubscriber subscriber)
        {
            // check if subscriber already exist
            if (IsSubscribed(subscriber))
            {
                return;
            }

            subscribers.Add(subscriber);
        }

        public void UnSubscribe(IOrientationChangedSubscriber subscriber)
        {
            var idx = IndexOfSubscriber(subscriber);

            if (idx == -1)
                return;
            
            subscribers.RemoveAt(idx);
        }

        public bool IsSubscribed(IOrientationChangedSubscriber subscriber)
        {
            return IndexOfSubscriber(subscriber) != -1;
        }

        private int IndexOfSubscriber(IOrientationChangedSubscriber subscriber)
        {
            return subscribers.FindIndex(
                (item) =>
                {
                    return Object.ReferenceEquals(item, subscriber);
                }
            );
        }


    }

}