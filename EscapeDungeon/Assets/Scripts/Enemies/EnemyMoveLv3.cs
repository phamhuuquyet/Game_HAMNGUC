using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMoveLv3 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform pointA;
    public Transform pointB;
    public Vector3 targetPoint;


    void Start()
    {
        targetPoint = pointB.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint,moveSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            if(Vector3.Distance(transform.position, pointB.position) < 0.2f)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.position.z);
                targetPoint = pointA.position;
            }
            else
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.position.z);


                targetPoint = pointB.position;
            }
        }
    }
}
