using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lclick : StateMachineBehaviour
{
    Animator anim;
    public GameObject sword;
    void Start()
    {
        anim = sword.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Active");
        }

       if (Input.GetMouseButtonUp(0))
        {

        }
    }
}
