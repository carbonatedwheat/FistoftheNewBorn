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
    public pAttack pAttack;
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
        }
        if (reset <= Time.time)
        {
            ok2Attack = true;
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                blocker.SetActive(true);
                light1 = heavy1 = false;
                blockerBool = true;
                Debug.Log("blocker enabled");
            }
            if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                anim.Play("Idle");
                blocker.SetActive(false);
                blockerBool = false;
            }
            if (blockerBool == false)
            {
                if(light1 == false)
                {
                    light2 = light3 = false;
                }
                if(heavy2 == false)
                {
                    heavy2 = heavy3 = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    //lightAttack.SetActive(true);
                    Debug.Log("Neutral Light");
                    anim.Play("Light1");
                    reset = lCD + Time.time;
                    ok2Attack = false;
                    light1 = true;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    //heavyAttack.SetActive(true);
                    Debug.Log("Neutral Heavy");
                    anim.Play("Heavy1");
                    reset = hCD + Time.time;
                    ok2Attack = false;
                    heavy1 = true;
                }
                if (!Input.GetMouseButtonDown(0) && reset <= Time.time)
                {
                    //lightAttack.SetActive(false);
                    light1 = false;
                    heavy1 = false;
                }
                if (!Input.GetMouseButtonDown(1) && reset <= Time.time)
                {
                    //heavyAttack.SetActive(false);
                    light1 = false;
                    heavy1 = false;
                }
                if (light1 == ok2Attack == true)
                {
                    heavy1 = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Light Combo 2");
                        anim.Play("Light2");
                        reset = lCD + Time.time;
                        ok2Attack = false;
                        light2 = true;
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("Neutral Heavy");
                        anim.Play("Heavy1");
                        reset = hCD + Time.time;
                        ok2Attack = false;
                        light1 = false;
                    }
                    if(light2 == ok2Attack == true)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Light Combo 3");
                            anim.Play("Light3");
                            light3 = true;
                            heavy1 = false;
                        }
                        if (Input.GetMouseButtonDown(1))
                        {
                            Debug.Log("Neutral Heavy");
                            anim.Play("Heavy1");
                            reset = hCD + Time.time;
                            light1 = false;
                            heavy1 = true;
                        }
                    }
                }
                if (heavy1 == true)
                {
                    light1 = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Neutral Light");
                        anim.Play("Light1");
                        ok2Attack = false;
                        heavy1 = false;
                        light1 = true;
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("Heavy Combo Heavy");
                        anim.Play("Heavy2");
                        reset = hCD + Time.time;
                        ok2Attack = false;
                        heavy2 = true;
                    }
                    if(heavy2 == true )
                    {
                        light1 = false;
                        if (Input.GetMouseButtonDown(0))
                        {
                            anim.Play("Light1");
                            //lightAttack.SetActive(true);
                            light1 = true;
                            heavy1 = false;
                        }
                        if (Input.GetMouseButtonDown(1))
                        {
                            anim.Play("Heavy3");
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