using UnityEngine;
using System.Collections;

public class ProductionInitializer : MonoBehaviour 
{
    public GameObject worldPrefab = null;
    public GameObject uiControlPrefab = null;

    void Awake()
    {
        Debug.AssertFormat(worldPrefab != null, "must have world prefab");

        #if UNITY_ANDROID || UNITY_IOS
        Debug.AssertFormat(uiControlPrefab != null, "mobile app must have UI control prefab");
        #endif
    }
    // after everything is initialized
    // spawn a world object
    void Start()
    {
        GameObject.Instantiate(worldPrefab, Vector3.zero, Quaternion.identity);

        #if UNITY_ANDROID || UNITY_IOS
        GameObject.Instantiate(uiControlPrefab, Vector3.zero, Quaternion.identity);
        TouchControl.Instance().DisableUIButton("Interact");
        #endif
    }
}
