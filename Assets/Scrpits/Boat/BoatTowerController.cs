using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatTowerController : MonoBehaviour
{
    public GameObject[] tower;
    private bool _enabled = false;
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
            _enabled = true;
        }

    }
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1) && _enabled)
        {
            foreach (GameObject circle in tower)
            {
                circle.SetActive(false);
                _enabled = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            Destroy(gameObject);
        }
    }
}

