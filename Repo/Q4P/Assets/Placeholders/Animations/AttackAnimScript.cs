using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimScript : MonoBehaviour
{
    public Animator anim;
    public Transform Player;
    public float aRange;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= aRange)
        {
            Debug.Log("Swing");
            anim.Play("Golem Swing");
            anim.Play("enemyAttack");
        }
        else
        {
            anim.Play("Walk Cycle");
        }
    }
       
}
