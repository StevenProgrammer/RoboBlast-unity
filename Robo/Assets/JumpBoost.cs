using UnityEngine;
using System.Collections;

public class JumpBoost : MonoBehaviour {

    public GameObject target;

    public GameObject RightThingy;
    public GameObject LeftThingy;

     public GameObject Leftwall;
     public GameObject Rightwall;

     public GameObject leftwallspawn;
     public GameObject rightwallspawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

       float xpos = target.transform.position.x;
        

	    //target.transform.position = new Vector3 (Mathf.Clamp(//, 65, 65))
       // target.transform.position = new Vector3(Mathf.Clamp(xpos, 65,65), 0,0);
	}


    void OnTriggerStay2D(Collider2D colli)
    {
        if(colli.gameObject.tag == "Player")
        {

            //GameObject fire1 = Instantiate(Fire, damageport1.transform.position, Quaternion.identity) as GameObject;

            GameObject left = Instantiate(Leftwall, leftwallspawn.transform.position, Quaternion.identity) as GameObject;
            GameObject right = Instantiate(Rightwall, rightwallspawn.transform.position, Quaternion.identity) as GameObject;



            target.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 900);
            RightThingy.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 400);
            LeftThingy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 400);
        }
    }


    void OnTriggerExit2D(Collider2D cool)
    {
        if(cool.gameObject.tag == "Player")
        {
            //target

           
        }
    }



}
