using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float RotationSpeed = 10;
    public Transform Target, Player;
    float mX, mY;
    // Camera mycam = GetComponent<Camera>();
    Vector3 offset;

    void Start()
    {


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        offset = Target.transform.position - transform.position;

    }
    void LateUpdate()
    {
        CamControl();
        //float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
       // float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        //transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
    }

    void CamControl()
    {
        mX += Input.GetAxis("mX") * RotationSpeed;
        mY += Input.GetAxis("mY") * RotationSpeed;
        mY = Mathf.Clamp(mY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mY, mX, 0);
        Player.rotation = Quaternion.Euler(0, mX, 0);


    }
}
