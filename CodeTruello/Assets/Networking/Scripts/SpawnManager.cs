using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady) {
            //PhotonNetwork.Instantiate();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
