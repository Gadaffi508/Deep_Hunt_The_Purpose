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
        GameObject[] towers = GameObject.FindGameObjectsWithTag("kule");
        foreach (GameObject _tower in towers)
        {
            _tower.SetActive(false);
        }
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

