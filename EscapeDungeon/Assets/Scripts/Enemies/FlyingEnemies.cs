using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour
{
    public float enemySpeed;
    private Transform player;
    public float LineOfSite;
    public GameObject enemyGraphic;
    bool facingRight = false;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
        float distanceFromPlyer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlyer < LineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
        }
    }
    void flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
    }
}
