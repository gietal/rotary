using UnityEngine;
using System.Collections;

public class ProductionInitializer : MonoBehaviour 
{
    public GameObject worldPrefab = null;

    void Awake()
    {
        Debug.AssertFormat(worldPrefab != null, "must have world prefab");
    }
    // after everything is initialized
    // spawn a world object
    void Start()
    {
        GameObject.Instantiate(worldPrefab, Vector3.zero, Quaternion.identity);
    }
}
