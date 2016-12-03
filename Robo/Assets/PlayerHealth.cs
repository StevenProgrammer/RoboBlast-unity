using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameObject PlayerBody;

    public float MyHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        PlayerHealthSystem();
	
	}

    void PlayerHealthSystem()
    {

    }


    void OnCollisionEnter2D(Collision2D coolo)
    {
        if(coolo.gameObject.tag == "EBullet")
        {
            MyHealth--;
        }
        if (coolo.gameObject.tag == "ERocket")
        {
            MyHealth -= 10;
        }

    }
}
