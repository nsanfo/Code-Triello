using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState : MonoBehaviour
{
    public GameObject weaponOwner;
    public float initialDamage;
    void Start()
    {
        initialDamage = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            weaponOwner = other.transform.parent.transform.parent.gameObject;
            Debug.Log(weaponOwner);
        }
    }
}
