using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour {

    public float eMaxHealth;
    public float eMinHealth;                           //LOL GET HACKED NERD XD
    public float eCurrentHealth;
    public GameObject Host;

    public DamageScript damage;
	// Use this for initialization
	void Start () {
        eCurrentHealth = eMaxHealth;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "HitBoxLight")
        {
            //eCurrentHealth -= 1;
            eCurrentHealth -= damage.Light;
            //eCurrentHealth -= damage.damageAmount = eCurrentHealth;
            Debug.Log("Checkem");
        }
        if (collision.gameObject.tag == "HitBoxHeavy")
        {
            //eCurrentHealth -= 1;
            eCurrentHealth -= damage.Heavy;
            //eCurrentHealth -= damage.damageAmount = eCurrentHealth;
            Debug.Log("dubs");
        }

    }
    // Update is called once per frame
    void Update () {
		if(eCurrentHealth <= eMinHealth)
        {
            Host.SetActive(false);
        }
	}
}
