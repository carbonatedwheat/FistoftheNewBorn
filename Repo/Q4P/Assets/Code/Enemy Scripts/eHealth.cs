using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour {

    public float eMaxHealth, eMinHealth, eCurrentHealth;
    public int pointValue;
    public GameObject Host;
    public WinCond wC;
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
            wC.Score += pointValue;
            gameObject.SetActive(false);
        }
	}
}