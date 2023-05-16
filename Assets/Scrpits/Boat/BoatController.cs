using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BoatController : MonoBehaviour
{
    [Header("Controller")]
    [Space]
    public Rigidbody2D rb;
    public float speed;
    float horizontal;
    public int Health;

    [Space]
    [Header("UI")]
    [Space]
    public Text healthText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartHealth();
    }

    void Update()
    {
        healthText.text = "Boat Health :" + Health;

        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
    public void Regeneraiton()
    {
        if (Health < 100)
        {
            Health += 5;
        }
        else
        {
            Health = 100;
        }
    }
    IEnumerator StartHealth()
    {
       yield return new WaitForSeconds(2);
        Regeneraiton();
        StartCoroutine(StartHealth());
    }
        
}
