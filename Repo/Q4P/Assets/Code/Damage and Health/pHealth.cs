using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pHealth : MonoBehaviour
{
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pBlock == false)
        {
            if (other.gameObject.tag == "HurtBox")
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
        if (pBlock == true)
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

    // Update is called once per frame
    void Update()
    {
        if (pCurrentHealth <= pMinHealth)
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);



        }


        if (pAttack.blockerBool == true)
        {
            pBlock = true;
        }
        if (pAttack.blockerBool == false)
        {
            pBlock = false;
        }
        
    }
}
