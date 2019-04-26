using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarz : MonoBehaviour
{
    private Transform bar;
    public pGeneral G;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
       // bar.localScale = new Vector3(1f, .4f);
    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
    // Update is called once per frame
    void Update()
    {
       bar.localScale = new Vector3(1f,G.pCurrentHealth * .01f);
    }
}
