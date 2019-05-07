using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
          PlayerMovement();   
    }
    void PlayerMovement()
    {
        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(Hor, 0f, Ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        //anim.Play("Walk Cycle");
    }
}
