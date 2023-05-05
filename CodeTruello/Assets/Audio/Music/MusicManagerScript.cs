using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{
    private int sceneID = -1;    // 0 = Generic, 1 = Old West, 2 = Wizard's Lair, 3 = Castle Courtyard

    public AudioClip[] genericMusic;

    public AudioClip[] westernMusic;

    public AudioClip[] wizardMusic;

    public AudioClip[] castleMusic;

    public AudioClip[] currSceneTracks;

    private AudioSource AS;

    private static MusicManagerScript instance = null;

    private void Awake()
    {
        // Check if there is an existing instance of the MusicManagerScript and destroy it if there is.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance to this MusicManagerScript and set it to not be destroyed when changing scenes.
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Check if the scene changed, if so, call OnSceneLoaded function.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        getSceneID();                           //When MainMenu loads, get the SceneID automatically
        AS = GetComponent<AudioSource>();       //Set the audio source to the audio source connected to "Music Manager"
        setTracks();                            //Set the tracks, or playlists, to the playlists placed into the Music Manager for each genre
        playMusic();                            //Begin playing the playlist
    }

    // Played on a new Scene being loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int prevSceneID = sceneID;              //Stores the ID of the previous scene
        getSceneID();                           //Stores current scene ID in sceneID global variable

        //If the previous scene is not the same genre of music as the current
        if (prevSceneID != sceneID)
        {
            AS = GetComponent<AudioSource>();   //Set the audio source to the audio source connected to "Music Manager"
            setTracks();                        //Set the tracks, or playlists, to the playlists placed into the Music Manager for each genre
            playMusic();                        //Begin playing the playlist
        }
        //if the previous scene is the same as te current scene's genre, do nothing and keep playing the music that was playing already
    }

    // Music Helpers
    private void setTracks()
    {
        currSceneTracks = genericMusic;  //Default value, will get reassigned if sceneID is between 0 and 4
                                                //Otherwise, error will be thrown anyway

        switch(sceneID)
        {
            case 0:
                currSceneTracks = genericMusic;
                break;
            case 1:
                currSceneTracks = westernMusic;
                break;
            case 2:
                currSceneTracks = wizardMusic;
                break;
            case 3:
                currSceneTracks = castleMusic;
                break;
            default:
                throw new System.Exception("sceneID must be between 0 and 4");
        }
    }

    private AudioClip chooseRandSong()
    {
        int rand = Random.Range(0, currSceneTracks.Length);

        return currSceneTracks[rand];
    }

    //Chooses a random song, then plays it, waits for Coroutine to end before playing next one.
    private void playMusic()
    {
        AudioClip song = chooseRandSong();

        AS.clip = song;
        AS.Play();
        //---------------------------------------- TESTING ----------------------------------------
        Debug.Log("Currently Playing:  " + AS.clip.name);
        //---------------------------------------- TESTING ----------------------------------------
        StartCoroutine(WaitForSongEnd(AS.clip.length));
    }

    //Waits for the length of the current song, and then plays the next random song.
    private System.Collections.IEnumerator WaitForSongEnd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        playMusic();
    }

    //Stores the current sceneID in the sceneID global variable based on the name of the scene.
    private void getSceneID()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu" || sceneName == "LoginScene" || sceneName == "Lobby")
            sceneID = 0;
        else if (sceneName == "WesternOldTown")
            sceneID = 1;
        else if (sceneName == "WizardLair")
            sceneID = 2;
        else if (sceneName == "CastleCourtyard")
            sceneID = 3;
    }
    
}