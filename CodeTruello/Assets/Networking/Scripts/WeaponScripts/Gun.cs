using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    
    public void Fire() {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        //spawnedBullet.AddComponent<Rigidbody>();
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.up;
        Destroy(spawnedBullet,2);
    }
}
