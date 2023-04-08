using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawnLoc : MonoBehaviour
{
    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(PlayerCount.NumberOfPlayers == 1) {
            // the player is local
            //this.gameObject.transform.position = new Vector3(0, 0, -123);
            SetLocAndRotRecursively(new Vector3(0, 0, -123), Quaternion.identity);
            Debug.Log("I am a local player");
            Debug.Log(PlayerCount.NumberOfPlayers);

        } else if(PlayerCount.NumberOfPlayers != 2) {
            // the player is remote
            //this.gameObject.transform.position = new Vector3(-11, 0, 16);
            Debug.Log("I am a remote player");
            // this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            SetLocAndRotRecursively(new Vector3(-11, 0, 16), Quaternion.Euler(new Vector3(0, 180, 0)));
            Debug.Log(PlayerCount.NumberOfPlayers);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SetLocAndRotRecursively(Vector3 pos, Quaternion rot)
    {
        //if (this == null) return;
        foreach (Transform trans in this.gameObject.GetComponentsInChildren<Transform>(true))
        {
            // direct child
            if(trans.parent == this.transform) {
                trans.position = pos;
                trans.rotation = rot;
            }
            
        }
    }
    void SetTag(string tagName) {
        foreach (Transform trans in this.gameObject.GetComponentsInChildren<Transform>(true))
        {
            // direct child
            if(trans.parent == this.transform) {
                trans.gameObject.tag = tagName;
            }
            
        }
    }
}
