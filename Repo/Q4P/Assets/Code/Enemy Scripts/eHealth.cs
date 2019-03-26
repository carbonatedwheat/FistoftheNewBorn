using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour {

    public float eMaxHealth;
    public float eMinHealth;
    public float eCurrentHealth;
    public GameObject Host;
	// Use this for initialization
	void Start () {
        eCurrentHealth = eMaxHealth;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "HitBox")
        {
            eCurrentHealth -= 1;
            //eCurrentHealth - damage = eCurrentHealth;
            Debug.Log("Checkem");
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
