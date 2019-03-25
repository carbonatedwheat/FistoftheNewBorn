using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        //float Vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //target.transform.Rotate(Vertical, 0, 0);

        //float DesiredAngle = target.transform.eulerAngles.x;
        //Quaternion rotation = Quaternion.Euler(DesiredAngle, 0, 0);
        //transform.position = target.transform.position - (rotation * offset);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation1 = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation1 * offset);

        transform.LookAt(target.transform);
    }
}
