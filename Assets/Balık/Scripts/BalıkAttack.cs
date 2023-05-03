using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BalıkAttack : MonoBehaviour
{
    public float TriggerRange;
    public float AttackRange;
    private Vector2 direction;
    public Transform target;
    private bool Detected;
    private bool Detected1;
    public float speed;
    private EnemyAI enemyAI;
    Rigidbody2D enemyRb;
    public float Force;
    private int forceNum = 1;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, TriggerRange);
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        enemyAI = GetComponent<EnemyAI>();
        enemyRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        TriggerPlayer();
    }

    private void TriggerPlayer()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D trigger = Physics2D.Raycast(transform.position, direction, TriggerRange);
        if (trigger)
        {
            if (trigger.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Debug.Log("iceride");
                    Detected = true;
                }
            }

        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
                Debug.Log("Dişarıda");
            }
        }

        if (Detected == true)
        {

            enemyAI.MovePlayer();
            EnemyAttack();
            EnemyAI.speed = 4f;
        }
        else
        {
            enemyAI.RandomMove();
        }
    }

    private void EnemyAttack()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D enemyAttack = Physics2D.Raycast(transform.position, direction, AttackRange);
        if (enemyAttack)
        {
            if (enemyAttack.collider.gameObject.CompareTag("Player"))
            {
                if (Detected1 == false)
                {
                    Debug.Log("2");
                    Detected1 = true;
                }
            }

        }
        else
        {
            if (Detected1 == true)
            {
                Detected1 = false;
                Debug.Log("1");
            }
        }

        if (Detected1 == true)
        {
            if (forceNum == 1)
            {
                enemyRb.velocity = new Vector2(enemyRb.velocity.x, Force * Time.fixedDeltaTime);
                forceNum = 0;
            }

        }
        else
        {
            forceNum = 1;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            enemyRb.gravityScale = 2f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            enemyRb.gravityScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deniz"))
        {
            //enemyRb.gravityScale = -1f;
        }
    }
    public Transform player;
    public RectTransform mapRect;
    public float mapScale = 700f;

    void LateUpdate()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2 mapPos = new Vector2(playerPos.x / mapScale, playerPos.y / mapScale);
        mapRect.anchoredPosition = mapPos;
    }
}
