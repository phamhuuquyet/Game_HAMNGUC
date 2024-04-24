using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardFireBall : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private Rigidbody2D rb;
    public float force;
    public float damage;
    float nextDamage;
    float damageRate = 0.5f;
    public GameObject Explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && nextDamage < Time.time)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = damageRate + Time.time;
            Destroy(gameObject);
        }
    }
}
