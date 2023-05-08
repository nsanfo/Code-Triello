using UnityEngine;

/*
 * Attatch an "SFX Manager" (found in MainMenu Screen)
 * Like, just copy and paste it onto the weapon and bullet and spell prefabs
 * Then you can just have the weapons and bullets and spells play the sound of impacts or shooting or whatever by just calling the public functions in this script
 * 
 * If you don't copy/paste the one from the Main Menu, you have to set up all the sounds individually, which is kinda a pain.
 */

public class SFXManagerScript : MonoBehaviour
{
    //Footstep SFX
    public AudioClip[] footstepsWood;
    public AudioClip[] footstepsSoil;

    //Gun SFX
    public AudioClip gunPickup;
    public AudioClip[] gunShoots;
    public AudioClip[] gunImpacts;

    //Sword SFX
    public AudioClip swordPickup;
    public AudioClip[] swordHits;
    public AudioClip[] swordMisses;

    //Wand SFX
    public AudioClip wandPickup;
    public AudioClip[] wandShoots;
    public AudioClip[] wandImpacts;

    //Misc SFX
    public AudioClip healthPickup;

    //Other Variables
    private AudioSource AS;

    private static SFXManagerScript instance = null;

    private int prev = -1;  //Previous number given by the getRandFromList, so you won't get the same sound twice.


    //Foosteps//

    // Plays a random Soil Footstep
    public void playFootstepSoil()
    {
        AS.clip = getRandFromList(footstepsSoil);
        AS.Play();
    }

    // Plays a random Wood Footstep
    public void playFootstepWood()
    {
        AS.clip = getRandFromList(footstepsWood);
        AS.Play();
    }


    //Gun//

    public void playGunPickup()
    {
        AS.clip = gunPickup;
        AS.Play();
    }

    public void playGunShoot()
    {
        AS.clip = getRandFromList(gunShoots);
        AS.Play();
    }
    public void playGunImpact()
    {
        AS.clip = getRandFromList(gunImpacts);
        AS.Play();
    }

    //Sword//
    public void playSwordPickup()
    {
        AS.clip = swordPickup;
        AS.Play();
    }
    public void playSwordHits()
    {
        AS.clip = getRandFromList(swordHits);
        AS.Play();
    }
    public void playSwordMisses()
    {
        AS.clip = getRandFromList(swordMisses);
        AS.Play();
    }

    //Wand//
    public void playWandPickup()
    {
        AS.clip = wandPickup;
        AS.Play();
    }
    public void playWandShoots()
    {
        AS.clip = getRandFromList(wandShoots);
        AS.Play();
    }
    public void playWandImpacts()
    {
        AS.clip = getRandFromList(wandImpacts);
        AS.Play();
    }

    //Misc//
    public void playHealthPickup()
    {
        AS.clip = healthPickup;
        AS.Play();
    }

    //Helpers//

    private AudioClip getRandFromList(AudioClip[] list)
    {
        int len = list.Length;

        //if the list only has 1 element, just return that element.
            //prevents infinite while loop
        if (len == 1)
            return list[0];

        int rand = UnityEngine.Random.Range(0, len);

        while (rand == prev)
            rand = UnityEngine.Random.Range(0, len);

        prev = rand;
        return list[rand];
    }

}
