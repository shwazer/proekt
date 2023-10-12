using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 7;
    public float moveH;
    public float moveV;
    Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * speed;
        moveV = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(moveH, moveV);

        if (moveV > 0)
        {
            //animator.SetTrigger("isUp");
            animator.SetBool("isRun", true);
        }
        else if (moveV < 0)
        {
            animator.SetBool("isDown", true);
        }
        else if (moveH > 0)
        {
            animator.SetBool("isRight", true);
        }
        else if (moveH < 0)
        {
            animator.SetBool("isLeft", true);
        }
        else if (moveH == 0 && moveV == 0)
        {
            //animator.SetTrigger("isIdle");
            animator.SetBool("isRun", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);

           // Debug.Log("idle");
        }
    }
    void FixedUpdate ()
    {
       
    }
}
