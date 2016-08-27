using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class ProductionGoalProcessor : IGoalDelegate 
{
    public override void OnPlayerEnterGoal(GameObject thePlayer)
    {
        var activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene + 1);
    }
}
