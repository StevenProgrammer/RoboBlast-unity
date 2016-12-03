using UnityEngine;
using System.Collections;

public class EnemySpawnSystem : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject Enemy;


    // Use this for initialization
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (enemies.Length >= 8)
        {
            print("lots of buggers");
        }
        else
        {
            InvokeRepeating("SpawnEnemies", 1, 5f);

        }



    }

    void SpawnEnemies()
    {
        int SpawnPos = Random.Range(0, (spawnPoints.Length - 1));

        Instantiate(Enemy, spawnPoints[SpawnPos].transform.position, transform.rotation);
        CancelInvoke();

    }
}
