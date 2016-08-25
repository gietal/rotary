using UnityEngine;
using System.Collections;

namespace Rotary
{
    public class DebugGoalProcessor : IGoalDelegate {

        public override void OnPlayerEnterGoal(GameObject thePlayer)
        {
            // show win screen
            Debug.Log(thePlayer.name + " enters the goal");
        }
    }

}