﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pGeneral : MonoBehaviour
{
    public GameObject lightAttack;
    public GameObject heavyAttack;
    public GameObject blocker;
    public WaitForSeconds comboLimit;
    public bool light1, heavy1, light2, heavy2, light3, heavy3, blockerBool;
    
    public float pMaxHealth;
    public float pMinHealth;
    public float pCurrentHealth;
    public bool pBlock;
    public pAttack pAttack;
    public DamageScript damage;
    // Start is called before the first frame update
    void Start()
    {
        pCurrentHealth = pMaxHealth;
        lightAttack.SetActive(false);
        heavyAttack.SetActive(false);
        blocker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pCurrentHealth <= pMinHealth)
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
        }
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            blocker.SetActive(true);
            lightAttack.SetActive(false);
            heavyAttack.SetActive(false);
            blockerBool = true;
            Debug.Log("blocker enabled");
        }
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            blocker.SetActive(false);
            blockerBool = false;
        }
        if (blockerBool == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lightAttack.SetActive(true);
                light1 = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                heavyAttack.SetActive(true);
                heavy1 = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                lightAttack.SetActive(false);
            }
            if (Input.GetMouseButtonUp(1))
            {
                heavyAttack.SetActive(false);
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
    private void OnTriggerEnter(Collider other)
    {
        if (blockerBool == false)
        {
            if (other.gameObject.tag == "HurtBox")
            {
                pCurrentHealth -= damage.enemy;
            }
            if (other.gameObject.tag == "SpiderStab")
            {
                pCurrentHealth -= damage.spiderStab;

            }
            if (other.gameObject.tag == "AntSlash")
            {
                pCurrentHealth -= damage.samuraiAntSlash;

            }
        }
        if (blockerBool == true)
        {
            if (other.gameObject.tag == "BlockSpell")
            {
                pCurrentHealth -= damage.spellingBlockSpell * 0.5f;

            }
            if (other.gameObject.tag == "SpiderStab")
            {
                pCurrentHealth -= damage.spiderStab * 0.5f;

            }
            if (other.gameObject.tag == "AntSlash")
            {
                pCurrentHealth -= damage.samuraiAntSlash * 0.5f;
                Debug.Log("Reduced Damage");
            }
            if (other.gameObject.tag == "BlockSpell")
            {
                pCurrentHealth -= damage.spellingBlockSpell * 0.5f;

            }
        }
    }

}
