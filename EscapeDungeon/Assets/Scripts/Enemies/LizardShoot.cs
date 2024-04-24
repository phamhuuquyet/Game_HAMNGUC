using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LizardShoot : MonoBehaviour
{

    public Transform Mouth;
    public GameObject lizardBullet;
    private Animator anim;
    private GameObject player;
    public AudioSource fireBreath;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 8)
        {
                anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }
    }void shoot()
    {
        fireBreath.Play();
        Instantiate(lizardBullet, Mouth.position, Quaternion.identity);
    }
}
