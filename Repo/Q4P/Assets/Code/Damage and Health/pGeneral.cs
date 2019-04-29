using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pGeneral : MonoBehaviour
{
    public GameObject lightAttack, heavyAttack, blocker;//pBlock;
    public bool light1, heavy1, light2, heavy2, light3, heavy3, blockerBool;
    public Slider healthSlider;
    public float pMaxHealth, pMinHealth, pCurrentHealth, attackTimer, attackCd;
    public pAttack pAttack;
    public DamageScript damage;
    public Animator anim;
    public AudioClip placeHolder;
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
        //healthSlider.value = pCurrentHealth;
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
            anim.Play("idle");
            blocker.SetActive(false);
            blockerBool = false;
        }
        if (blockerBool == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lightAttack.SetActive(true);
                anim.Play("lightpunch");
                Debug.Log("Neutral Light");
                light1 = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                heavyAttack.SetActive(true);
                anim.Play("heavypunch");
                Debug.Log("Neutral Heavy");
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
                    Debug.Log("Light Combo Light");
                    lightAttack.SetActive(true);
                    light2 = true;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Neutral Heavy");
                    heavyAttack.SetActive(true);
                    heavy1 = true;
                    light1 = false;
                }
            }
            if (heavy1 == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    lightAttack.SetActive(true);
                    light1 = true;
                    Debug.Log("Neutral Heavy");
                    heavy1 = false;
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