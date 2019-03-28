using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHealth : MonoBehaviour
{
    public float pMaxHealth;
    public float pMinHealth;
    public float pCurrentHealth;
   
    public DamageScript damage;
    // Start is called before the first frame update
    void Start()
    {
        pCurrentHealth = pMaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {
            pCurrentHealth -= damage.enemy;

        }
        if (collision.gameObject.tag == "SpiderStab")
        {
            pCurrentHealth -= damage.spiderStab;
            
        }
        if (collision.gameObject.tag == "AntSlash")
        {
            pCurrentHealth -= damage.samuraiAntSlash;
            
        }
        if (collision.gameObject.tag == "BlockSpell")
        {
            pCurrentHealth -= damage.spellingBlockSpell;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pCurrentHealth <= pMinHealth)
        {
            Debug.Log("Game Over");
        }
    }
}
