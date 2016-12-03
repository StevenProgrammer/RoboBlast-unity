using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float BulletLife = 5f;

    bool killbullet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        BulletLifeSpan();
        BulletSystem();
        
	}


    void BulletLifeSpan()
    {
        BulletLife -= Time.deltaTime;
    }

    void BulletSystem()
    {
        if(BulletLife <= 0)
        {
            Destroy(gameObject);
        }
        
    }


    void OnTriggerEnter2D(Collider2D coolo)
    {
        if (coolo.gameObject.tag == "Enemy")
        {
            Debug.Log("MOOO");
            BulletLife = 0;

        }
        else
        {
            if (coolo.gameObject.tag == "Environment")
            {
                BulletLife = 0;
            }
        }
    }



}
