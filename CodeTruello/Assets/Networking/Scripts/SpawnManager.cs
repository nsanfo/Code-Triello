using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject GenericVRPlayerPrefab;
    
    public Vector3 spawnPosition;
    public GameObject SpawnCharWeapon;

    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady) {
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
            if(SpawnCharWeapon != null) {
                PhotonNetwork.Instantiate(SpawnCharWeapon.name, spawnPosition, Quaternion.identity);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
