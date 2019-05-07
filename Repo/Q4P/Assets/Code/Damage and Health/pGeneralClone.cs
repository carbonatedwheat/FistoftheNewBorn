﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pGeneralClone : MonoBehaviour
{
    public GameObject lightAttack, heavyAttack, blocker;//pBlock;
    public bool light1, heavy1, light2, heavy2, light3, heavy3, blockerBool, ok2Attack;
    public bool m1Down, m2Down;
    public bool m1Held, m2Held;
    public float speed, pMaxHealth, pMinHealth, pCurrentHealth, attackTimer, aCD, lCD, hCD, reset;
    public DamageScript damage;
    public Animator anim;
    public AudioClip placeHolder, punch1, punch2, punch3, punch4, punch5, punch6;
    public Time timer;
    // Start is called before the first frame update
    void Start()
    {
        m1Down = false;
        m2Down = true;
        pCurrentHealth = pMaxHealth;
        lightAttack.SetActive(false);
        heavyAttack.SetActive(false);
        blocker.SetActive(false);
        reset = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        m1Down = Input.GetMouseButtonDown(0);
        m2Down = Input.GetMouseButtonDown(1);
        m1Held = Input.GetMouseButton(0);
        m2Held = Input.GetMouseButton(1);

        Debug.Log("B" + ":" + m1Down + " " + m2Down + " " + m1Held + " " + m2Held);

       
        // Debug.Log(Time.time + " " + aCD + " " + reset);

        if (pCurrentHealth > pMaxHealth)
        {
            pCurrentHealth = pMaxHealth;
        }
        //healthSlider.value = pCurrentHealth;
        if (pCurrentHealth <= pMinHealth)
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
        }

        if (light1 == false)
        {
            light2 = light3 = false;
        }
        if (heavy1 == false)
        {
            heavy2 = heavy3 = false;
        }

        if (Input.GetKey(KeyCode.W) && ok2Attack == true && blockerBool == false
            || Input.GetKey(KeyCode.S) && ok2Attack == true && blockerBool == false
            || Input.GetKey(KeyCode.A) && ok2Attack == true && blockerBool == false
            || Input.GetKey(KeyCode.D) && ok2Attack == true && blockerBool == false)
        {
            anim.Play("Walk Cycle");
            PlayerMovement();
        }
        else if (Input.GetKey(KeyCode.W) && ok2Attack == true && blockerBool == true
                 || Input.GetKey(KeyCode.S) && ok2Attack == true && blockerBool == true
                 || Input.GetKey(KeyCode.A) && ok2Attack == true && blockerBool == true
                 || Input.GetKey(KeyCode.D) && ok2Attack == true && blockerBool == true)
        {
            anim.Play("Block");
            PlayerMovement();
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)
            && light1 == false && heavy1 == false && blockerBool == false)
        {
            anim.Play("Idle");
        }

        if (aCD >= Time.time)
        {
            ok2Attack = false;
            lightAttack.SetActive(false);
            heavyAttack.SetActive(false);
        }
        //if (ok2Attack == false)
        //{
        //    reset = lCD + aCD * 2;
        //}
        if (reset <= Time.time && aCD <= Time.time)
        {
            light1 = heavy1 = false;
        }
        if (aCD <= Time.time)
        {
            ok2Attack = true;
            if (m1Down == true && m2Down == true )
            {
                blocker.SetActive(true);
                light1 = heavy1 = false;
                blockerBool = true;
                anim.Play("Block");
                Debug.Log("blocker enabled");
            }
            if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                blocker.SetActive(false);
                blockerBool = false;
            }
            if (blockerBool == false && ok2Attack == true)
            {
                if (!Input.GetMouseButtonDown(0) && reset + 1.5f <= Time.time)
                {
                    //lightAttack.SetActive(false);
                    light1 = false;
                }
                if (!Input.GetMouseButtonDown(1) && reset + 1.5f <= Time.time)
                {
                    //heavyAttack.SetActive(false);
                    heavy1 = false;
                }
                if (Input.GetMouseButtonDown(0)) //Light Click for a light combo starter
                {
                    //lightAttack.SetActive(true);
                    Debug.Log("Neutral Light");
                    anim.Play("Light1");
                    lightAttack.SetActive(true);
                    light1 = true;
                    reset = lCD * 2 + Time.time;
                    aCD = lCD + Time.time;
                    ok2Attack = false;
                }
                if (Input.GetMouseButtonDown(1)) //Right Click for a heavy combo starter
                {
                    //heavyAttack.SetActive(true);
                    Debug.Log(":::::::::::::::::::::::::::::Neutral Heavy");
                    anim.Play("Heavy1");
                    heavyAttack.SetActive(true);
                    aCD = hCD + Time.time;
                    ok2Attack = false;
                    heavy1 = true;
                }
                if (light1 == true && ok2Attack == true)
                {
                    if (Input.GetMouseButton(0)) //Left Click for second light in the chain
                    {
                        Debug.Log("Light Combo 2");
                        lightAttack.SetActive(true);
                        anim.Play("Light2");
                        light2 = true;
                        reset = lCD * 2 + Time.time;
                        aCD = lCD + Time.time;
                        ok2Attack = false;
                    }
                    if (Input.GetMouseButtonDown(1)) //Right Click to start from a neutral heavy
                    {
                        Debug.Log("Neutral Heavy");
                        heavyAttack.SetActive(true);
                        anim.Play("Heavy1");
                        light1 = false;
                        aCD = hCD + Time.time;
                        ok2Attack = false;
                    }
                    if (light2 == true && ok2Attack == true)
                    {
                        //Debug.Log("LIGHT2 is TRUE    and ok2ATTACK is true " + Time.time);
                        //heavy1 = false;
                        Debug.Log("++++++++++++++++++" + m1Held + " " + Input.GetKey(KeyCode.E) + " " + m2Held);

                        if (m1Held) /*if(Input.GetMouseButton(0))*/  //Left Click for third light in the chain
                        {
                            Debug.Log("Light Combo 3");
                            lightAttack.SetActive(true);
                            anim.Play("Light3");
                            aCD = lCD + Time.time;
                            reset = lCD * 2 + Time.time;
                            light3 = true;
                            ok2Attack = false;
                        }
                        //if (Input.GetMouseButtonDown(1)) //Right Click to start from a neutral heavy
                        //{
                        //    Debug.Log("Neutral Heavy");
                        //    heavyAttack.SetActive(true);
                        //    anim.Play("Heavy1");
                        //    aCD = hCD + Time.time;
                        //    ok2Attack = false;
                        //    light1 = false;
                        //}
                    }
                }
                //Debug.Log((heavy1 == true && ok2Attack == true) + "  ?????????????  " + (heavy1 == ok2Attack == true));
                
                if (heavy1 == true && ok2Attack == true)
                {
                    light1 = false;
                    if (Input.GetMouseButtonDown(0)) //Left Click to start from a neutral light
                    {
                        Debug.Log("Neutral Light");
                        lightAttack.SetActive(true);
                        anim.Play("Light1");
                        aCD = lCD + Time.time;
                        ok2Attack = false;
                        heavy1 = false;
                        light1 = true;
                    }
                    if (Input.GetMouseButtonDown(1)) //Right Click for second heavy in the chain
                    {
                        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Heavy Combo Heavy");
                        heavyAttack.SetActive(true);
                        anim.Play("Heavy2");
                        aCD = hCD + Time.time;
                        ok2Attack = false;
                        heavy2 = true;
                    }
                    if (heavy2 == true && ok2Attack == true)
                    {
                        light1 = false;
                        if (Input.GetMouseButtonDown(0)) //Left Click to start from a neutral light
                        {
                            anim.Play("Light1");
                            lightAttack.SetActive(true);
                            light1 = true;
                            aCD = lCD + Time.time;
                            heavy1 = false;
                        }
                        if (Input.GetMouseButtonDown(1)) //Right Click for third heavy in the chain
                        {
                            anim.Play("Heavy3");
                            heavyAttack.SetActive(true);
                            aCD = hCD + Time.time;
                            heavy3 = true;
                            light1 = false;
                        }
                    }
                }
            }
        }

        m1Down = Input.GetMouseButtonDown(0);
        m2Down = Input.GetMouseButtonDown(1);
        m1Held = Input.GetMouseButton(0);
        m2Held = Input.GetMouseButton(1);

        Debug.Log("E" + ":" + m1Down + " " + m2Down + " " + m1Held + " " + m2Held);


    }
    void PlayerMovement()
    {
        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(Hor, 0f, Ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (blockerBool == false)
        {
            if (other.gameObject.tag == "KillZone")
            {
                pCurrentHealth -= damage.killZone;
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
            if (other.gameObject.tag == "KillZone")
            {
                pCurrentHealth -= damage.killZone;
            }
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