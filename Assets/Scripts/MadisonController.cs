using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadisonController : MonoBehaviour {

    [SerializeField] private float maxSpeed = 10f;
    bool facingRight = true;
    Rigidbody2D body;
    public bool canMove;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            body.velocity = Vector3.zero;
            return;
        }
        float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");

        body.velocity = new Vector3(moveH * maxSpeed, 0, 0);

        if (moveH > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveH < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
