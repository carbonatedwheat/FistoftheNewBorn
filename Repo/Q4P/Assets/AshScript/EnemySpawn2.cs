using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 1f;
    public int enemyCount = 10;
    public Transform[] spawnPoints;
    bool isSpawning = true;
    public int Wave;
    public bool wave1Done;
    //Spawn Delay Variables
    float SpawnAlarm;
    float SpawnTime = 1f;
    public TextMesh Wavenum;


    void Start()
    {
        Debug.Log("Enemies Left:" + enemyCount);
        Wave = 1;
        
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    public void Spawning()
    {

        if( isSpawning == true)
        {
            if(SpawnAlarm-Time.deltaTime > 0)
            {
                SpawnAlarm -= Time.deltaTime;
            }
            else
            {
                Spawn();
                SpawnAlarm = SpawnTime;
            }
                
        }
        else
        {

            Debug.Log("Stop spawning");

        }

    }
    void NextWave()
    {
        if (enemyCount == 0)
        {

            Wave += 1;
        }
    }


    void Update()
    {
        //Find Amount Of Enemies In Scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Debug.Log("It is Wave:" + Wave);

        if (Wave == 1)
        {
            if (enemyCount == 1)
            {
                isSpawning = true;
            }
            if (enemyCount == 6)
            {
                isSpawning = false;
            }
            if (enemyCount == 0)
            {

                NextWave();

            }

        }
        else if (Wave == 2)
        {

            if (enemyCount == 0)
            {
                isSpawning = true;
            }
            if (enemyCount == 10)
            {
                isSpawning = false;
            }
            if (enemyCount == 0)
            {
                NextWave();
            }


        }
        else if (Wave == 3)
        {
            if (enemyCount == 0) 
            {
                isSpawning = true;
            }
           
                
        }
        
        Spawning();

        Wavenum.text = "Wave:" + Wave;

    }
    

}
