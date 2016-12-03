using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {

    //declare that we will use a gameobject
     GameObject BulletGreen;

	// Use this for initialization
	void Start ()
    {
        //when the game starts define what our declared gameobject will be by grabing it out of the resouces folder
        BulletGreen = Resources.Load("gBullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        ShootControls();
	
	}

    void ShootControls()
    {

        
     
        if (Input.GetKeyDown(KeyCode.E))
        {
            //shoot the bullet
            Debug.Log("i have shot the bullet");

            GameObject gbullet = Instantiate(BulletGreen) as GameObject;


            //shoots to the right
            gbullet.transform.position = transform.position + transform.right * 2;

            Rigidbody2D rb = gbullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * 10;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject gbullet = Instantiate(BulletGreen) as GameObject;


                //shoots to the left
                gbullet.transform.position = transform.position + transform.right * -2;

                Rigidbody2D rb = gbullet.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * -10;
            }
        }

        
    }
}
