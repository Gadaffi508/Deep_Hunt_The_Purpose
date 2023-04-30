using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    float horizontal;

    bool jump;
    public float jumpAmount = 10;

    public BoatController ship; // gemi nesnesi
    private bool isOnShip = false; // karakterin gemide olup olmadýðýný kontrol eden deðiþken
    bool touchship = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindGameObjectWithTag("boat").gameObject.GetComponent<BoatController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jump==true)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jump = false;
            
        }

        if (Input.GetKey(KeyCode.B)) // "B" tuþuna basýldýðýnda
        {
            isOnShip = true;
        }
        if (isOnShip && touchship == true) // karakter gemideyse
        {
            ship.rb.velocity = new Vector2(horizontal * speed, ship.rb.velocity.y); // gemiyi hareket ettir
            transform.position = new Vector2(ship.transform.position.x,transform.position.y);
            rb.velocity = new Vector2(horizontal * 0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.B)) // "B" tuþuna basmayý býraktýðýnda
        {
            isOnShip = false;
        }
        if (!isOnShip) // karakter gemideyse
        {
            ship.rb.velocity = new Vector2(horizontal * 0, ship.rb.velocity.y); // gemiyi hareket ettir
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jump = true;
        }
        if (other.gameObject.CompareTag("boat"))
        {
            jump = true;
            touchship = true;
        }
        else
        {
            touchship = false;
        }
    }
}
