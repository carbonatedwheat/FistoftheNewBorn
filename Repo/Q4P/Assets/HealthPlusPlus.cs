using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlusPlus : MonoBehaviour
{
    public float speed = 10f;
    public float xspeed = 5f;
    float height = 0.25f;
    public pGeneral G;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        Vector3 pos = transform.position;
       
        float newY = Mathf.Sin(Time.time * xspeed) * height + pos.y;
       
        transform.position = new Vector3(pos.x, newY, pos.z) * height;
    }
}
