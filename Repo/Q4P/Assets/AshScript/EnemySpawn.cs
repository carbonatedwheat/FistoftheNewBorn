using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy;
    public float sTime = 2f;
    public Transform[] sPoints;
    
    void Start()
    {

        InvokeRepeating("Spawn", sTime, sTime);
        
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, sPoints.Length);
        Instantiate(Enemy, sPoints[spawnPointIndex].position, sPoints[spawnPointIndex].rotation);

    }

    
    void Update()
    {


        
    }
}
