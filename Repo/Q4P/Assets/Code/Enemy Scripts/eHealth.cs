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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HitBoxLight")
        {
            Debug.Log("Checkem");
            eCurrentHealth -= damage.Light;
            
        }
        if (other.gameObject.tag == "HitBoxHeavy")
        {
            Debug.Log("dubs");
            eCurrentHealth -= damage.Heavy;
            
        }

    }
    // Update is called once per frame
    void Update () {
		if(eCurrentHealth <= eMinHealth)
        {
            gameObject.SetActive(false);
        }
	}
}