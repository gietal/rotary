using UnityEngine;
using System.Collections;

public abstract class IGoalDelegate : MonoBehaviour
{
    public abstract void OnPlayerEnterGoal(GameObject thePlayer);
}
