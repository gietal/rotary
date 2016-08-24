using UnityEngine;
using System.Collections;

namespace Rotary 
{
    
    public class PlayerSpawner : MonoBehaviour {

        public GameObject playerPrefab = null;
        public GameObject cameraPrefab = null;

        void Awake()
        {
            Debug.Assert(playerPrefab != null);
            Debug.Assert(cameraPrefab != null);

            var player = (GameObject)GameObject.Instantiate(playerPrefab, this.transform.position, this.transform.rotation);
            var camera = (GameObject)GameObject.Instantiate(cameraPrefab, this.transform.position, this.transform.rotation);

            var follow = camera.GetComponent<UnityStandardAssets.Cameras.AutoCam>();
            follow.SetTarget(player.transform);
        }
    }
}
