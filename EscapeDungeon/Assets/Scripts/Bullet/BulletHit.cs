using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    Bullet myBullet;
    public float stayTime;
    public GameObject Explosion;
    public float bulletDamage;
    // Start is called before the first frame update
    private void Awake()
    {
        myBullet = GetComponentInParent<Bullet>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            myBullet.removeForce();
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.addDamage(bulletDamage);
        }
    }
    
}
