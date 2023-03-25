using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class WeaponMultiplayerSpawn : MonoBehaviour
{
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(SceneManager.GetActiveScene().name != "Lobby"){ 
            if(photonView.IsMine) {
                // the player is local
                this.gameObject.transform.position = new Vector3(0, 2, -120);
                Debug.Log("I am a local weapon player");

            } else {
                // the player is remote

                this.gameObject.transform.position = new Vector3(-11, 2, 13);
                Debug.Log("I am a remote weapon player");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
