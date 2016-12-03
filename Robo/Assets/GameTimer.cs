using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    //is how to set up minutes + second timer
    //public float Seconds, Minutes;


    public static float GameTime = 204;

    //3:24


    public Text TimeCounter;

    public GameObject[] SpawnPoints;
    public GameObject Enemies;

    
    

	// Use this for initialization
	void Start ()
    {
        //can declre what the public game object we called for earlier is right here with a gameobject name = 
        TimeCounter = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update ()
    {
        BasicNGUISystem();
        MainTimeSystem();
        SubTimeSystem();
        TimerBasics();
	}

    void BasicNGUISystem()
    {

        //set up minute to second counter
        /*
        //declare the formulas for minutes and seconds to make it easier to read the timer
        Minutes = (int)(Time.time / 60f);
        Seconds = (int)(Time.time % 60f);
        //if scene changing better to use Time.timeSinceLevelLoad
        TimeCounter.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
        */


        //TimeCounter.text = GameTime.ToString("");

    }

    void TimerBasics()
    {
        GameTime -= Time.deltaTime;
    }

    void MainTimeSystem()
    {
        if(GameTime >= 0.1)
        {
            //game is active
        }
        else
        {
            if(GameTime <= 0)
            {
                //game is over
            }
        }
    }

    void SubTimeSystem()
    {
        //every couple of seconds spawn an enemy using the array for spawners
        //if more than 8 are out dont spawn any more
    }

    /*
    void OnTriggerEnter2D(Collider2D colli)
    {
        if(colli.gameObject.tag == "Player")
        {
           rigidbody.addforce 
        }
    }
    */



   
}
