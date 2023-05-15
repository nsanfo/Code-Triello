using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Wand : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    
   public void Fire() {
        GameObject spawnedBullet = PhotonNetwork.Instantiate("Star", barrel.position, barrel.rotation);
        //spawnedBullet.AddComponent<Rigidbody>();
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.up;
        Destroy(spawnedBullet,2);
    }
}
