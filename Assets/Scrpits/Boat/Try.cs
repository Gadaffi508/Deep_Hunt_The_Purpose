using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour
{
    public LayerMask moveObjectLayer;
    public Camera cam;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, moveObjectLayer);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
