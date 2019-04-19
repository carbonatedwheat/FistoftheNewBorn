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

    void Start()
    {
        
        Player = GameObject.FindWithTag("Player").transform;

    }

    void Update()
    {
        transform.LookAt(Player);


        if (Vector3.Distance(transform.position, Player.position) >= Min)
        {

            transform.position += transform.forward * speed * Time.deltaTime;
     
        }
        if (Vector3.Distance(transform.position, Player.position) <= Max)
        {


        }

        if (paused)
        {
            return;
        }
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
