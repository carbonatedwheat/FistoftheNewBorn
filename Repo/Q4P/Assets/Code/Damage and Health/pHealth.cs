using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HurtBox")
        {
<<<<<<< HEAD
<<<<<<< HEAD
            if (other.gameObject.tag == "HurtBox")
            {
                pCurrentHealth -= damage.killZone;
            }
            if (other.gameObject.tag == "SpiderStab")
            {
                pCurrentHealth -= damage.spiderStab;
=======
=======
>>>>>>> parent of 5118e49... a
            pCurrentHealth -= damage.enemy;
        }
        if (other.gameObject.tag == "SpiderStab")
        {
            pCurrentHealth -= damage.spiderStab;
<<<<<<< HEAD
>>>>>>> parent of 5118e49... a
=======
>>>>>>> parent of 5118e49... a

        }
        if (other.gameObject.tag == "AntSlash")
        {
            pCurrentHealth -= damage.samuraiAntSlash;

        }
        if (other.gameObject.tag == "BlockSpell")
        {
            pCurrentHealth -= damage.spellingBlockSpell;

        }
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
            //Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
            //gameObject.SetActive(false);
<<<<<<< HEAD


=======


>>>>>>> parent of 5118e49... a

        }
    }
}
