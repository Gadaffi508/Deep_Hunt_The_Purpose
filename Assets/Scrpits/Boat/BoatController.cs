using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour
{
    [Header("Controller")]
    [Space]
    public Rigidbody2D rb;
    public float speed;
    float horizontal;
    public int Health;
    public int damage;

    [Space]
    [Header("UI")]
    [Space]
    public Text healthText;
    public Text GoldText;

    [Space]
    [Header("Gold")]
    public int gold;

    Try tow;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        healthText.text = "Boat Health :" + Health.ToString();
        GoldText.text = "Gold : " + gold.ToString();

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
    IEnumerator DamageSlowTýme()
    {
        yield return new WaitForSeconds(2);
        DamageSlow(damage);
        StartCoroutine(DamageSlowTýme());

    }
    public void DamageSlow(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            other.transform.parent = transform;
            Destroy(other.rigidbody);
        }
    }

}
