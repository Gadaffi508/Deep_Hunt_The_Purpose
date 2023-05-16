using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatTowerController : MonoBehaviour
{
    public LayerMask OpenTowerObject;
    public LayerMask CloseTowerObject;

    public GameObject[] tower;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
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
            RaycastHit2D hot = Physics2D.Raycast(mousePosition, direction, float.MaxValue, CloseTowerObject);
            if (hot.collider != null)
            {
                foreach (GameObject circle in tower)
                {
                    circle.SetActive(false);
                }
            }
        }
    }
}

