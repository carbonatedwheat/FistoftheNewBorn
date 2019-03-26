using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float Max;
    public float Min;
    public Transform Player;


    void Start()
    {



    }

    void Update()
    {


        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= Min)
        {



            transform.position += transform.forward * speed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= Max)
            {


                //Here Call any function U want Like Shoot at here or something


            }
        }
    }
}
