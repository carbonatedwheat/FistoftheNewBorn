using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarzOfHealth : MonoBehaviour
{
    public pGeneral G;
    public Transform bar;


    void Start()
    {
        bar = transform.Find("Bar");
        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(1f, sizeNormalized);
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(1f, G.pCurrentHealth* .01f);
    }
}
