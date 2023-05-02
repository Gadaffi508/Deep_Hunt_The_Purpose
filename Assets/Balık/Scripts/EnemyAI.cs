using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float RandomX;
    private float RandomY;
    public Vector2 nextPoint;
    public float d�stance;
    public static float speed = 2f;
    private Transform target;
    void Start()
    {
        RandomX = Random.Range(-15f, 15f);
        RandomY = Random.Range(-4f, 0.10f);
        nextPoint = new Vector2(RandomX, RandomY);
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        RandomMove();

    }

    public void RandomMove()
    {
        d�stance = Vector2.Distance(transform.position, nextPoint);
        transform.position = Vector2.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        if (d�stance <= 1)
        {
            RandomX = Random.Range(-9f, 10f);
            RandomY = Random.Range(-4f, 0.10f);
            nextPoint = new Vector2(RandomX, RandomY);
            transform.position = Vector2.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        }
    }
    public void MovePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
