using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DController : MonoBehaviour
{


    bool isJumping = false;
    bool isRunning = false;

    string direction = "right";

    private Rigidbody2D rb2d;
    private Animator anim;

    public float BASE_SPEED = 5f;
    public float JUMP_FORCE = 500f;

    private float speed = 1f;

    private readonly int STATUS_STAND = 0;
    private readonly int STATUS_RUN = 1;
    private readonly int STATUS_WALK = 2;
    private readonly int STATUS_JUMP = 3;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb2d.velocity = Vector2.zero;
    }

    public void ButtonDownForward()
    {
        direction = "right";
        transform.localScale = new Vector3(1, 1);

        if (isRunning)
        {
            speed = BASE_SPEED * 1.5f;
            anim.SetInteger("status", STATUS_RUN);
        }
        else
        {
            speed = BASE_SPEED;
            anim.SetInteger("status", STATUS_WALK);
        }
    }

    public void ButtonUpForward()
    {
        speed = 0;
        anim.SetInteger("status", STATUS_STAND);
    }

    public void ButtonDownBackward()
    {
        direction = "left";
        transform.localScale = new Vector3(-1, 1);

        if (isRunning)
        {
            speed = -BASE_SPEED * 1.5f;
            anim.SetInteger("status", STATUS_RUN);
        }
        else
        {
            speed = -BASE_SPEED;
            anim.SetInteger("status", STATUS_WALK);
        }
    }

    public void ButtonUpBackward()
    {
        speed = 0;

        anim.SetInteger("status", STATUS_STAND);
    }

    public void ButtonDownRun()
    {
        isRunning = true;
        speed = -BASE_SPEED * 1.5f;
        anim.SetInteger("status", STATUS_RUN);
    }

    public void ButtonUpRun()
    {
        isRunning = false;
        speed = 0;
        anim.SetInteger("status", STATUS_STAND);
    }
    public void ButtonDownJump()
    {
        if (isJumping)
            return;

        anim.SetBool("isJumping", true);
        isJumping = true;
        rb2d.AddForce(new Vector2(0, JUMP_FORCE));
    }

    public void ButtonDownShoot()
    {
        Debug.Log("I'm shooting");
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            rb2d.velocity = new Vector3(speed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector3(speed * 1.5f, rb2d.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        anim.SetBool("isJumping", false);
    }

}
