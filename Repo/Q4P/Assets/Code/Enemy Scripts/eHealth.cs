using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour {

    public float eMaxHealth;
    public float eMinHealth;                           
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
            eCurrentHealth -= damage.Light;
            Debug.Log("Checkem");
        }
        if (collision.gameObject.tag == "HitBoxHeavy")
        {
            eCurrentHealth -= damage.Heavy;
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
