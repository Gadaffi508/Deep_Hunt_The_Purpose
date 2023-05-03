using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Collider2D collision;

    float horizontal;

    public bool jump;
    public float jumpAmount = 10;

    public BoatController ship; // gemi nesnesi
    private bool isOnShip = false; // karakterin gemide olup olmadýðýný kontrol eden deðiþken
    bool touchship = false;

    [Header("Material")]
    public GameObject Zýpkýn;


    void Start()
    {
        Zýpkýn.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindGameObjectWithTag("boat").gameObject.GetComponent<BoatController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

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

            if (horizontal > 0 && isOnShip)
            {
                ship.transform.localScale = new Vector2(1, 1);
            }
            if (horizontal < 0 && isOnShip)
            {
                ship.transform.localScale = new Vector2(-1, 1);
            }
        }

        if (Input.GetKeyUp(KeyCode.B)) // "B" tuþuna basmayý býraktýðýnda
        {
            isOnShip = false;
        }
        if (!isOnShip) // karakter gemide deðilse
        {
            ship.rb.velocity = new Vector2(0, ship.rb.velocity.y); // gemiyi hareket ettirmeme
        }
        if (horizontal > 0)
        {
            transform.localScale = new Vector2(1,1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("boat"))
        {
            jump = true;
        }
        else if(other.gameObject.CompareTag("WaterColllider"))
        {
            jump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BoatController"))
        {
            jump = false;
            touchship = true;
        }
        else
        {
            touchship = false;
        }
        if (other.gameObject.CompareTag("material"))
        {
            Destroy(other.gameObject);
            Zýpkýn.SetActive(true);
        }
    }
}
