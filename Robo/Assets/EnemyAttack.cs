using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    //public GameObject[] attacks;

    bool facingright = false;
    bool facingleft = false;
    float attacklife =1;
    public int attackcount;
    public GameObject attacker;
    public Transform Player;
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float damping;
    public Transform fpsTarget;





    // Use this for initialization
    void Start()
    {
        attacker = Resources.Load("redrocket") as GameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(attacklife <= 0)
        {
            attackcount -= 1;
        }

        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            // myRender.material.color = Color.blue;
            lookAtPlayer();
        }
        if (fpsTargetDistance < attackDistance)
        {
            //attackPlease();
            attacklife = 1;
            InvokeRepeating("attackPlease", 1, 5f);
            //print("Attack");
        }
        else
        {
            if(fpsTargetDistance > attackDistance)
            {
                // myRender.material.color = Color.cyan;
                //print("me cant attack...yet");
            }
        
        }
    }

    void lookAtPlayer()
    {
    }

    void attackPlease()
    {
        //invoke attacks on player
        if(attackcount <= 1)
        {
            //summon the spell
            GameObject Rocket = Instantiate(attacker) as GameObject;
            Rocket.transform.position = gameObject.transform.forward;
            Rigidbody BS = Rocket.GetComponent<Rigidbody>();
            BS.velocity = gameObject.transform.forward * 40;
            attackcount += 1;
            attacklife -= Time.deltaTime;
        }
         

        //give attacks velocity and rigid bodies
//print("i am attacking");
        CancelInvoke();
        

    }


    void Awake()
    {
        fpsTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
