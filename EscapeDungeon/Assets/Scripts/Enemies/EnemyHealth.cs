using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public AudioSource gettinghited;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        gettinghited.Play();
        if (currentHealth <= 0)
            makeDead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
    
    }
    void makeDead()
    {
        gettinghited.Play();
        Destroy(gameObject);
    }
}
