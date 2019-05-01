using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAttack : MonoBehaviour
{
    public GameObject lightAttack;
    public GameObject heavyAttack;
    public GameObject blocker;
    public WaitForSeconds comboLimit;
    public float lCD, hCD, reset;
    public bool light1, heavy1, light2, heavy2, light3, heavy3, blockerBool;

    // Start is called before the first frame update
    void Start()
    {
        lightAttack.SetActive(false);
        heavyAttack.SetActive(false);
        blocker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            blocker.SetActive(true);
            lightAttack.SetActive(false);
            heavyAttack.SetActive(false);
            blockerBool = true;
            //pHealth.pBlock.Equals(true);
            Debug.Log("blocker enabled");
        }
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            blocker.SetActive(false);
            blockerBool = false;
            //pHealth.pBlock = false;
        }
        if (blockerBool == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lightAttack.SetActive(true);
                light1 = true;
                reset = lCD + Time.time;
            }
            if (Input.GetMouseButtonDown(1))
            {
                heavyAttack.SetActive(true);
                reset = hCD + Time.time;
                heavy1 = true;
            }
            if (!Input.GetMouseButtonDown(0) && reset <= Time.time)
            {
                light1 = false;
            }
            if (!Input.GetMouseButtonDown(1) && reset <= Time.time)
            {
                heavy1 = false;
            }

            if (light1 == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("LightComboLight");
                    lightAttack.SetActive(true);
                    light2 = true;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("LightComboHeavy");
                    heavyAttack.SetActive(true);
                    heavy2 = true;
                }
            }
            if (heavy1 == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lightAttack.SetActive(true);
                    light1 = true;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    heavyAttack.SetActive(true);
                    heavy2 = true;
                }
            }
        }
    }
    
}
