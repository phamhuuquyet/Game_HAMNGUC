using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadder : MonoBehaviour
{

    public float vertical;
    private float speed = 3f;
    private bool isLadder;
    private bool isClimbing;

    private Animator anim;
    private string Climb_Animation = "Climb";
    private string Jump_Animation = "Jump";

    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            anim.SetBool(Climb_Animation, true);
        }
        else
        {
            rb.gravityScale = 1f;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            anim.SetBool(Jump_Animation, false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool(Climb_Animation, false);
        }
    }

}
