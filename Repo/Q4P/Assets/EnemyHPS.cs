using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPS : MonoBehaviour
{
    public eHealth E;

    public Transform bar;


    void Start()
    {
        bar = transform.Find("Bar");

    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(E.eCurrentHealth* 0.05f,1f);
    }
}
