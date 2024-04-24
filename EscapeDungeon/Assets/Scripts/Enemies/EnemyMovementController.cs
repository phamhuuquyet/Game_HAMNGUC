using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Animator anim;

    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    // Start is called before the first frame update
    private string Walk_Animation = "Walk";
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!facingRight)
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            anim.SetBool(Walk_Animation, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool(Walk_Animation, false);
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
        }
         
    }
    void flip()
    {
        if(!canFlip)
          return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
