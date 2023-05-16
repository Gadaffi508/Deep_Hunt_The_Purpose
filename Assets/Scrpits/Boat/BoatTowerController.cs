using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatTowerController : MonoBehaviour
{
    public GameObject[] towerT;
    public LayerMask OpenTowerObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
            {
                GameObject[] Towers = GameObject.FindGameObjectsWithTag("kule");
                foreach (var tower in Towers)
                {
                    tower.SetActive(false);
                }

                foreach (var towers in towerT)
                {
                    towers.SetActive(true);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject circle in towerT)
            {
                circle.SetActive(false);
            }
        }
    }
}

