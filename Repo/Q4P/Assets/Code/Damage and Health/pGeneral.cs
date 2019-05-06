using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pGeneral : MonoBehaviour
{
    public GameObject lightAttack, heavyAttack, blocker;//pBlock;
    public bool light1, heavy1, light2, heavy2, light3, heavy3, blockerBool, ok2Attack;
    public float pMaxHealth, pMinHealth, pCurrentHealth, attackTimer, attackCd, lCD, hCD, reset;
    public DamageScript damage;
    public Animator anim;
    public AudioClip placeHolder, punch1, punch2, punch3, punch4, punch5, punch6;
    // Start is called before the first frame update
    void Start()
    {
        pCurrentHealth = pMaxHealth;
        lightAttack.SetActive(false);
        heavyAttack.SetActive(false);
        blocker.SetActive(false);
        reset = Time.time;
    }
    // Update is called once per frame
    void Update()
    {

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
        if (reset >= Time.time)
        {
            ok2Attack = false;
            lightAttack.SetActive(false);
            heavyAttack.SetActive(false);
        }
        if (light1 == false)
        {
            light2 = light3 = false;
        }
        if (heavy1 == false)
        {
            heavy2 = heavy3 = false;
        }
        if (reset <= Time.time)
        {
            ok2Attack = true;
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                blocker.SetActive(true);
                light1 = heavy1 = false;
                blockerBool = true;
                anim.Play("Block");
                Debug.Log("blocker enabled");
            }
            if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                anim.Play("Idle");
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
                    reset = lCD + Time.time;
                    ok2Attack = false;
                    light1 = true;
                }
                if (Input.GetMouseButtonDown(1)) //Right Click for a heavy combo starter
                {
                    //heavyAttack.SetActive(true);
                    Debug.Log("Neutral Heavy");
                    anim.Play("Heavy1");
                    heavyAttack.SetActive(true);
                    reset = hCD + Time.time;
                    ok2Attack = false;
                    heavy1 = true;
                }
                if (light1 == ok2Attack == true)
                {
                    heavy1 = false;
                    if (Input.GetMouseButtonDown(0)) //Left Click for second light in the chain
                    {
                        Debug.Log("Light Combo 2");
                        lightAttack.SetActive(true);
                        anim.Play("Light2");
                        reset = lCD + Time.time;
                        ok2Attack = false;
                        light2 = true;
                    }
                    if (Input.GetMouseButtonDown(1)) //Right Click to start from a neutral heavy
                    {
                        Debug.Log("Neutral Heavy");
                        heavyAttack.SetActive(true);
                        anim.Play("Heavy1");
                        reset = hCD + Time.time;
                        ok2Attack = false;
                        light1 = false;
                    }
                    if (light2 == ok2Attack == true)
                    {
                        if (Input.GetMouseButtonDown(0)) //Left Click for third light in the chain
                        {
                            Debug.Log("Light Combo 3");
                            lightAttack.SetActive(true);
                            anim.Play("Light3");
                            reset = lCD + Time.time;
                            ok2Attack = false;
                            light3 = true;
                        }
                        if (Input.GetMouseButtonDown(1)) //Right Click to start from a neutral heavy
                        {
                            Debug.Log("Neutral Heavy");
                            heavyAttack.SetActive(true);
                            anim.Play("Heavy1");
                            reset = hCD + Time.time;
                            ok2Attack = false;
                            light1 = false;
                        }
                    }
                }
                if (heavy1 == ok2Attack == true)
                {
                    light1 = false;
                    if (Input.GetMouseButtonDown(0)) //Left Click to start from a neutral light
                    {
                        Debug.Log("Neutral Light");
                        lightAttack.SetActive(true);
                        anim.Play("Light1");
                        reset = lCD + Time.time;
                        ok2Attack = false;
                        heavy1 = false;
                        light1 = true;
                    }
                    if (Input.GetMouseButtonDown(1)) //Right Click for second heavy in the chain
                    {
                        Debug.Log("Heavy Combo Heavy");
                        heavyAttack.SetActive(true);
                        anim.Play("Heavy2");
                        reset = hCD + Time.time;
                        ok2Attack = false;
                        heavy2 = true;
                    }
                    if (heavy2 == ok2Attack == true)
                    {
                        light1 = false;
                        if (Input.GetMouseButtonDown(0)) //Left Click to start from a neutral light
                        {
                            anim.Play("Light1");
                            lightAttack.SetActive(true);
                            reset = lCD + Time.time;
                            light1 = true;
                            heavy1 = false;
                        }
                        if (Input.GetMouseButtonDown(1)) //Right Click for third heavy in the chain
                        {
                            anim.Play("Heavy3");
                            heavyAttack.SetActive(true);
                            reset = hCD + Time.time;
                            heavy3 = true;
                            light1 = false;
                        }
                    }
                }
            }
        }
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