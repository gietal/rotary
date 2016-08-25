using UnityEngine;
using System.Collections;

namespace Rotary
{
    
    public class GoalBehaviour : MonoBehaviour 
    {
        public IGoalDelegate goalDelegate = null;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if (goalDelegate != null)
                {
                    goalDelegate.OnPlayerEnterGoal(other.gameObject);
                }
            }
        }
    }

}