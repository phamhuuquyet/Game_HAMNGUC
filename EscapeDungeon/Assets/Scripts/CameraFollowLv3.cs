using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLv3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothing;

    Vector3 offset;


    void Start()
    {
        transform.position = target.position;
    }
   void FixedUpdate()
    {
        Vector3 cam = transform.position;
        cam.z = -10;

        transform.position = cam;

        transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
        /*if (transform.position.y < lowY)
            transform.position = new Vector3(transform.position.x,lowY,transform.position.z);*/
    }
}
