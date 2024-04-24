using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SawController : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float moveSpeed = 3f;
    public Transform pointA;
    public Transform pointB;
    private Vector3 targetPoint;


    void Start()
    {
        targetPoint = pointA.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, rotationSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint)<0.1f)
        {
            if (transform.position==pointA.position)
            {
                targetPoint=pointB.position;
            }
            else
            {
                targetPoint=pointA.position;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }



}
