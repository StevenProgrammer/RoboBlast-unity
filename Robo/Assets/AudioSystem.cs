using UnityEngine;
using System.Collections;

public class AudioSystem : MonoBehaviour {

    public AudioSource MainSound;
    public AudioSource PlayerDamaged;
    public AudioSource EnemyHurt;
    public AudioSource EnemyDead;
    public AudioSource PowerUpHealth;

    public AudioSource EnemySpawn;
    




	// Use this for initialization
	void Start ()
    {
        MainSound.Play();
	}
	
	// Update is called once per frame
	void Update () {

        SoundPlay();
	}


    void SoundPlay()
    {

        if(GameVariables.EnemyCoreHit == true)
        {
            EnemyHurt.Play();
            Debug.Log("moop");
            GameVariables.EnemyCoreHit = false;
            Debug.Log("noonb");
        }

        if (GameVariables.KillCount >= 1)
        {
            EnemyDead.Play();
            Debug.Log("add to score");
           
        }

        if(GameVariables.HealthPickup == true)
        {
            PowerUpHealth.Play();
            Debug.Log("PickupSound");
            GameVariables.HealthPickup = false;
            Debug.Log("Done_With_Pickup;");

        }

        if(GameVariables.PlayerIsHit == true)
        {
            PlayerDamaged.Play();
            Debug.Log("Player_Hurt_Sound");
            GameVariables.PlayerIsHit = false;
            Debug.Log("No_more_Player_hurt_sound");
        }

        if(GameVariables.EnemySpawnSound == true)
        {
            EnemySpawn.Play();
            Debug.Log("Im Here");
        }




    }
}
