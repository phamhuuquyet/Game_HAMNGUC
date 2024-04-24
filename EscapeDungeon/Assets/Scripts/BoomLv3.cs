using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoomLv3 : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
    }
    private void Update()
    {
        CheckPlayer();
    }

    public void CheckPlayer()
    {
        RaycastHit2D[] Hit = Physics2D.RaycastAll(transform.position, Vector3.down, 10f);

        if (Hit.Length > 0)
        {
            foreach (var item in Hit)
            {
                if (item.transform.GetComponent<Player>())
                {
                    rb.gravityScale = 1f;
                }
            }


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        
        if (player != null)
        {
            player.makeDead();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Move();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }


    }

    public void Move()
    {
        rb.velocity = Vector3.right * 5f;
    }
}
