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
<<<<<<< HEAD
            anim.Play("Golem Swing");
=======
>>>>>>> 47b36ecae29e7e732637bd9b06a0bb49827afdc8
            anim.Play("enemyAttack");
        }
        else
        {
            anim.Play("nomove");
        }
    }
       
}
