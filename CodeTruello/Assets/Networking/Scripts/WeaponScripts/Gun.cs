using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    
    public void Fire() {
        GameObject spawnedBullet = PhotonNetwork.Instantiate("Bullet", barrel.position, barrel.rotation);
        //spawnedBullet.AddComponent<Rigidbody>();
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.up;
        Destroy(spawnedBullet,2);
    }
}
