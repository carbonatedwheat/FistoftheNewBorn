using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyoom : MonoBehaviour
{
    public Vector3 v3;
    public float speed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVetrical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVetrical);

        rb.AddForce(movement * speed);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    Vector3 movement = new Vector3()
        //}
    }
}
