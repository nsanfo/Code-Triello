using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    [SerializeField]
    LWeaponManager wpnManager;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is touching me.");
            if(wpnManager != null) {
                wpnManager.ObjectName = this.gameObject.name;
            }
            
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }

    // void Start() {
    //     if(SceneManager.GetActiveScene().buildIndex == 7) {
    //         SetLayerRecursively(this.gameObject, 9);
    //     }
    // }

    // void SetLayerRecursively(GameObject go, int layerNumber)
    // {
    //     if (go == null) return;
    //     foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
    //     {
    //         trans.gameObject.layer = layerNumber;
    //     }
    // }
}
