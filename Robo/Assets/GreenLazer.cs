using UnityEngine;
using System.Collections;

public class GreenLazer : MonoBehaviour {

    public GameObject ParticleSpawn;

    public float life = 1;

    public GameObject hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (life == 0)
        {
            GameObject mhit = Instantiate(hit, ParticleSpawn.transform.position, Quaternion.identity) as GameObject;
            mhit.transform.parent = gameObject.transform;
            Destroy(gameObject);
        }
	}

    void CollisionEnter2d(Collision2D colli)
    {
        if (colli.gameObject.tag == "Enemy")
        {
            //fire1.transform.parent = EnemyBody.transform;
            life = 0;
        }
        else
        {
            if(colli.gameObject.tag == "Environment")
            {
                life = 0;
                //Debug.Log("boop");
            }
        }
    }
}
