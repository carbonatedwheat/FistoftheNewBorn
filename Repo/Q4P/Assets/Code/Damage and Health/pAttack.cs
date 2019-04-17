using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAttack : MonoBehaviour
{
    public GameObject lightAttack;
    public GameObject heavyAttack;
    // Start is called before the first frame update
    void Start()
    {
        lightAttack.SetActive(false);
        heavyAttack.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lightAttack.SetActive(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            heavyAttack.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lightAttack.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            heavyAttack.SetActive(false);
        }
        //else
        //{
        //    lightAttack.SetActive(false);
        //    heavyAttack.SetActive(false);
        //}
    }
}
