using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float Max;
    public float Min;
    public float aRange;
    public Transform Player;


    void Start()
    {
        
        Player = GameObject.FindWithTag("Player").transform;
        anim.GetComponentInChildren<Animator>();
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
        if(Vector3.Distance(transform.position, Player.position) >= aRange)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
