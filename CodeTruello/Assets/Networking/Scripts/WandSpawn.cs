using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WandSpawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is touching me.");
            DontDestroyOnLoad(this.gameObject);
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
}
