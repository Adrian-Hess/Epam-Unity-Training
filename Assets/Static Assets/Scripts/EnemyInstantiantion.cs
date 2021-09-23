using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiantion : MonoBehaviour
{

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    public GameObject[] enemy;
    public Transform[] spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    //void Spawn()
    //{
    //    int number = Random.Range(1, 10);
    //    GameObject[] gameObjects = new GameObject[number];
    //    for (int i = 0; i < number; i++)
    //    {
    //        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
    //        Instantiate(enemy, pos, Quaternion.identity);
    //    }
    //}

    private void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
