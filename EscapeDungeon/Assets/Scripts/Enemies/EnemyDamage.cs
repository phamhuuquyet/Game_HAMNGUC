using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    float damageRate = 0.5f;
    public float pushBackForce;
    float nextDamage;
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y -transform.position.y)).normalized;
        Vector2 pushDirectionHoz = new Vector2((transform.position.x-pushedObject.position.x ),0).normalized;
        pushDirection *= pushBackForce;
        pushDirectionHoz *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
        pushRB.AddForce(pushDirectionHoz, ForceMode2D.Impulse);
    }
}
