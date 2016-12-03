using UnityEngine;
using System.Collections;


public class PillarScript : MonoBehaviour {


    public GameObject kersplode;


    

	// Use this for initialization
	void Start ()
    {
        kersplode = Resources.Load("splode") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.tag == "ERocket")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 900);
            Instantiate(kersplode, transform.position, Quaternion.identity);
            Debug.Log("kepsploded");

            //destroy gameObject after about 3 seconds
            Destroy(gameObject, 3);




        }
        else
        {
            if (colli.gameObject.tag == "Bullet")
            {
               gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
               Debug.Log("foof");
               
               
            }
        }
    }
}
