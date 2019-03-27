using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHealth : MonoBehaviour
{
    public float pCurrentHealth;
    public float pMaxHealth;
    public float pMinHealth;
    // Start is called before the first frame update
    void Start()
    {
        pCurrentHealth = pMaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
