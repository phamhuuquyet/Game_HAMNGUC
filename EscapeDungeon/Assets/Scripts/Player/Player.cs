using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Moving
    [SerializeField]
    public float moveForce = 8f;
    [SerializeField]
    public float jumpForce = 6f;
    bool facingRight;

    public AudioSource walking;
    public AudioSource shooting;
    public AudioSource jumping;
    //Grounded checking when jump and land
    private bool isGrounded;

    //Shooting
    public Transform Gun;
    public GameObject Bullet;
    private bool isRunning = false;
    float fireRate = 0.5f;
    float nextFire = 0;

    [SerializeField]
    private Rigidbody2D myBody;

    public BoxCollider2D Collider;
    private Animator anim;

    //Animation name
    private string Jump_Animation = "Jump";
    private string GROUND_TAG = "Ground";


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));
        myBody.velocity = new Vector2(move * moveForce, myBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            flip();
            isRunning = true;
            if(isGrounded)
               walking.Play();

        }
        else if (move < 0 && facingRight)
        {
            isRunning = true;
            flip();
            if (isGrounded)
                walking.Play();
        }
        else if (move == 0)
        {
            isRunning = false;
            walking.Pause();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                anim.SetBool(Jump_Animation,true);
                walking.Pause();
                jumping.Play();
            }
        }
        //Shooting
        if (Input.GetKey(KeyCode.X))
        {
            fireBullet();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG) )
        {
            isGrounded = true;
            anim.SetBool(Jump_Animation, false);
            walking.Play();
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
            anim.SetBool(Jump_Animation, false);
        }


        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(4);
        }

    }
    //Shooting function
    void fireBullet()
    {
        if(Time.time > nextFire){
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                if (isRunning)
                {
                    shooting.Play();
                    anim.SetTrigger("RunShoot");
                    Instantiate(Bullet, Gun.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    shooting.Play();
                    anim.SetTrigger("Shoot");
                    Instantiate(Bullet, Gun.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
               
            }
            else if (!facingRight){
                if(isRunning)
                {
                    shooting.Play();
                    anim.SetTrigger("RunShoot");
                    Instantiate(Bullet, Gun.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
                else
                {
                    shooting.Play();
                    anim.SetTrigger("Shoot");
                    Instantiate(Bullet, Gun.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
        }
    }
}
