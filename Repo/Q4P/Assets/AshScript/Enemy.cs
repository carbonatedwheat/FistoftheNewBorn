using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float Max;
    public float Min;
    public bool inRange;
    public Transform Player;
    private bool paused = false;
    public float AttackDur = 2f;
    public Transform enemy;
    public float Emin = 3f;

    float SpeedDir = 1;

    void Start()
    {

        Player = GameObject.FindWithTag("Player").transform;
        enemy = GameObject.FindWithTag("Enemy").transform;

    }

    void Update()
    {
        transform.LookAt(Player);


        if (Vector3.Distance(transform.position, Player.position) >= Min)
        {

            transform.position += transform.forward * speed*SpeedDir * Time.deltaTime;
     
        }
        if (Vector3.Distance(transform.position, Player.position) <= Max)
        {


        }

        if (paused)
        {
            return;
        }

        //if(Vector3.Distance(transform.position, enemy.position) <= Emin)
        //{
        //    SpeedDir = -1;

        //}else// if (Vector3.Distance(transform.position, enemy.position) > Emin)
        //{
        //    SpeedDir = 1;
        //}


    }

    IEnumerator delay()
    {
        paused = true;
        yield return new WaitForSeconds(AttackDur);
        paused = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            paused = true;
        }

    }
}
