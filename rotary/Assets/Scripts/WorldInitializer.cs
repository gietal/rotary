using UnityEngine;
using System.Collections;

public class WorldInitializer : MonoBehaviour {

    void Start()
    {
        // parent all objects in the scene to me
        var transforms = GameObject.FindObjectsOfType<Transform>();
        foreach (var t in transforms)
        {
            // only deal with top level objects
            if (t.parent != null)
                continue;

            // skip cameras and player etc
            if (t.tag == "MainCamera" || t.tag == "Player")
                continue;

            // parent all top level objects to the world hinge
            t.parent = this.transform;
        }
    }
}
