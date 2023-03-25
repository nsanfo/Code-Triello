using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     DontDestroyOnLoad(gameObject);
    // }
}
