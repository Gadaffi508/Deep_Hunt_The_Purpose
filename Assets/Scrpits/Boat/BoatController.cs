using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody2D rb;

    PlayerMovement pl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
    }
}
