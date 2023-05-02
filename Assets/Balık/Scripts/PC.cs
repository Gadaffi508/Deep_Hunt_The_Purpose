using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 150f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizonalMove = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizonalMove * speed * Time.deltaTime, rb.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            rb.gravityScale = 2f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            rb.gravityScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            rb.gravityScale = 0f;
        }
    }
}
