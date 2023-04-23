using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MusicManagerScript : MonoBehaviour
{
    public int sceneID = -1;    // 0 = Main Menu, 1 = Lobby, 2 = Old West, 3 = Wizard's Lair, 4 = Castle Courtyard

    public AudioClip[] genericMusic;

    public AudioClip[] westernMusic;

    public AudioClip[] wizardMusic;

    public AudioClip[] castleMusic;

    public AudioClip[] currSceneTracks;

    private AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        setTracks();
        playMusic();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            skipSong();
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
                currSceneTracks = genericMusic;
                break;
            case 2:
                currSceneTracks = westernMusic;
                break;
            case 3:
                currSceneTracks = wizardMusic;
                break;
            case 4:
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

    //Testing Functions
        //I don't wanna wait for each entire song to finish, so i made this..

    void skipSong()
    {
        StopCoroutine("WaitForSongEnd");
        playMusic();
    }
    
}