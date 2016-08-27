using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rotary
{
    
    public class OrientationController : MonoBehaviour
    {

        private static OrientationController instance;

        private List<IOrientationChangedSubscriber> subscribers = new List<IOrientationChangedSubscriber>();

        [HideInInspector]
        public bool isRotating { get; private set; }

        [HideInInspector]
        public float currentAngle { get; private set; }

        public static OrientationController Instance()
        {
            return instance;
        }

        public OrientationController()
        {
            isRotating = false;
            currentAngle = 0;
            instance = this;
        }

        /*
         * rotation axis is z+ which is forward, so to rotate right
         * we actually have to do negative angle
        */
        public void RotateRight()
        {
            Rotate(-90);
        }

        public void RotateLeft()
        {
            Rotate(90);
        }

        void Rotate(int angle)
        {
            if (isRotating)
                return;

            isRotating = true;

            StartCoroutine(TweenAngleCoroutine(angle, 0.2f));

        }

        void NotifyOrientationChanged(float newAngle)
        {
            subscribers.ForEach(
                (subscriber) =>
                {
                    subscriber.OnOrientationChanged((float)currentAngle);
                }
            );
        }
        
        IEnumerator TweenAngleCoroutine(float angleChange, float targetSeconds)
        {
            Debug.Log("begin TweenAngle Coroutine ");
            // how many times to change angle per second
            const int stepsPerSecond = 60;

            // how much time to wait between angle change
            const float waitPerStep = 1.0f / (float)stepsPerSecond;

            // how many times to step
            // will be bad with odd targetSeconds
            int stepCount = (int)(stepsPerSecond * targetSeconds);


            float anglePerSecond = (float)angleChange / targetSeconds;

            float anglePerStep = Time.fixedDeltaTime * anglePerSecond;
            float anglePerStepAbs = Mathf.Abs(anglePerStep);

            while(Mathf.Abs(angleChange) >= float.Epsilon)
            {
                // if the remaining angle to 
                if (Mathf.Abs(angleChange) < anglePerStepAbs)
                {
                    // dont step the full angle
                    anglePerStep = angleChange;
                }

                // update current angle
                currentAngle += anglePerStep;

                // reduce remaining angle to step
                angleChange -= anglePerStep;

                // clamp current angle to [0, 359]
                if (currentAngle >= 360)
                    currentAngle -= 360;
                if (currentAngle < 0)
                    currentAngle += 360;

                // notify subscribers, they will handle themselves
                NotifyOrientationChanged(currentAngle);

                yield return new WaitForFixedUpdate();
            }

            isRotating = false;

            Debug.Log("end TweenAngle Coroutine ");
        }

        // subscribing

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