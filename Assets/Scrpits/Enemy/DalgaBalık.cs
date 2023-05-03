using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DalgaBalık : MonoBehaviour
{
    public float Radius;
    private Rigidbody2D rigidbody2;
    public Transform target;
    private Vector2 direction;
    private bool Detected;
    public float Range,AttackForce,FireRate;
    public float upFoce;
    private int AttackNum;
    private EnemyAI enemyAI;
    public Transform leftPoint, rightPoint;
    public GameObject Wave;
    private float nextTimeFireRate;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        AttackNum = 1;
        Physics2D.queriesStartInColliders = false;
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        EnemyTrigger();
        leftRightCast();
    }
    private void FixedUpdate()
    {
     
    }
    private void leftRightCast()
    {
        RaycastHit2D leftCast = Physics2D.Raycast(transform.position,-transform.right,Range);
        if (leftCast.collider != null)
        {
            Debug.DrawLine(transform.position, leftCast.point, Color.red);
            if (Time.time > nextTimeFireRate)
            {
                nextTimeFireRate = Time.time + 1 / FireRate;
                LeftWaveAttack();
            }
           
        }
        if (leftCast.collider == null)
        {
            Debug.DrawLine(transform.position, leftCast.point, Color.green);
            
        }
        RaycastHit2D rightCast = Physics2D.Raycast(transform.position, transform.right, Range);
        if (rightCast.collider != null)
        {
            Debug.DrawLine(transform.position, rightCast.point, Color.red);
            if (Time.time > nextTimeFireRate)
            {
                nextTimeFireRate = Time.time + 1 / FireRate;
                RightWaveAttack();
            }
           
        }
        if (rightCast.collider == null)
        {
            Debug.DrawLine(transform.position, rightCast.point, Color.green);

        }
    }
    
    private void EnemyTrigger()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D triggerEnemy = Physics2D.Raycast(transform.position, direction,Radius);
        if (triggerEnemy)
        {
            if (triggerEnemy.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Detected = true;
                    Debug.Log("Oldu");
                }
            }
          
        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
                Debug.Log("cıktık");
            }
        }


        if (Detected)
        {
            if (AttackNum == 1)
            {
                SurFace();
                EnemyAI.speed = 0f;
                AttackNum = 0;
            }

        }
        else
        {
            AttackNum = 1;
            EnemyAI.speed = 9f;
        }
    }
    private void LeftWaveAttack()
    {
        GameObject WaveIns = Instantiate(Wave,leftPoint.position,Quaternion.identity);
        WaveIns.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttackForce);
    }
    private void RightWaveAttack()
    {
        GameObject WaveIns = Instantiate(Wave, rightPoint.position, Quaternion.identity);
        WaveIns.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttackForce );
    }
    private void SurFace()
    {
        rigidbody2.velocity = new Vector2(rigidbody2.velocity.x,upFoce * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            rigidbody2.gravityScale = 2f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            rigidbody2.gravityScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            //rigidbody2.gravityScale = -1f;
        }
    }
}
