using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;

    public float damage;
    float damageRate = 0.5f;
    float nextDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if(isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            if(hit.transform != null)
            {
                if(hit.transform.tag == "Player")
                {
                    rb.gravityScale = 4;
                    isFalling = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
     {
       PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
       playerHealth.addDamage(damage);
       nextDamage = damageRate + Time.time;
       Destroy(gameObject);
     }
      if(collision.gameObject.tag == "Ground")
      {
            Destroy(gameObject);
      }

    }
   
}
