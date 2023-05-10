using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatTowerController : MonoBehaviour
{
    public GameObject[] tower;

    private void OnMouseDown()
    {
        foreach (GameObject circle in tower)
        {
            circle.SetActive(true);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            Destroy(gameObject);
        }
    }
}

