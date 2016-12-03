using UnityEngine;
using System.Collections;

public class EnemyDamageBox : MonoBehaviour
{

   

    public GameObject MainLight;

    private bool Ishit = false;
    public float EHealth = 5f;
    public GameObject EnemyBody;

    bool Dead = false;

    public GameObject damageport1;
    public GameObject damageport2;
    public GameObject damageport3;
    public GameObject damageport4;

    public GameObject explosion;
    public GameObject Fire;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //set up functions
        StuffThatEffectsHealth();
    }

    void StuffThatEffectsHealth()
    {
        if (Ishit == true)
        {
            EHealth--;
        }

    }


    void OnTriggerEnter2D(Collider2D collo)
    {

        //if collides with player
        if (collo.gameObject.tag == "Bullet")
        {
            //post on console
            Debug.Log("dammit");

            // bool to true so we can have it affect our health in a sepreate health script

            //for now we testing with is hit so its easier to use.
            EHealth--;
        }
        else
        {
            if (collo.gameObject.tag == "GreenLazor")
            {
                EHealth -= 5;
                GameVariables.KillCount++;
            }
        }

        if (EHealth <= 4)
        {
            //spawn first fire
            Debug.Log("ow");
            //instantiate fire at damage port1 location

            GameObject fire1 = Instantiate(Fire, damageport1.transform.position, Quaternion.identity) as GameObject;
            //parent fire1 to enemybody
            fire1.transform.parent = EnemyBody.transform;

            if (Dead == true)
            {
                Destroy(fire1);
            }
        }

        if (EHealth <= 3)
        {
            //spawn second fire
            Debug.Log("stop it");
            //instantiate fire at damage port 2 location

            GameObject fire2 = Instantiate(Fire, damageport2.transform.position, Quaternion.identity) as GameObject;
            //parent fire1 to enemybody
            fire2.transform.parent = EnemyBody.transform;

            if (Dead == true)
            {
                Destroy(fire2);
            }
        }

        if (EHealth <= 2)
        {
            //spawn third fire
            Debug.Log("no seriously");
            //instantiate fire at damage port 3 location

            GameObject fire3 = Instantiate(Fire, damageport3.transform.position, Quaternion.identity) as GameObject;
            //parent fire1 to enemybody
            fire3.transform.parent = EnemyBody.transform;

            if (Dead == true)
            {
                Destroy(fire3);
            }
        }

        if (EHealth <= 1)
        {
            //spawn forth fire
            Debug.Log("i mean it");
            //instantiate fire at damage port 4 location

            GameObject fire4 = Instantiate(Fire, damageport4.transform.position, Quaternion.identity) as GameObject;
            //parent fire1 to enemybody
            fire4.transform.parent = EnemyBody.transform;

            if (Dead == true)
            {
                Destroy(fire4);
            }
        }

        if (EHealth <= 0)
        {

            //if health is 0 gravity forces the 2d gaem object down
            EnemyBody.GetComponent<Rigidbody2D>().gravityScale = 10;

            Dead = true;
            //explode
            Debug.Log("i will be avenged");
            //instantiate explosion at enemybody location


            GameObject xplode = Instantiate(explosion, EnemyBody.transform.position, Quaternion.identity) as GameObject;
            //parent fire1 to enemybody
            xplode.transform.parent = EnemyBody.transform;


            //destroy the gameobject and add to kill counter
            //Destroy(EnemyBody);
            GameVariables.KillCount++;

            //destroy game object in .3 seconds
            Destroy(EnemyBody, 1);
        }
    }
}
