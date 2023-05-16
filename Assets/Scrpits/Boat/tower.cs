using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public GameObject Tower;
    public LayerMask MeLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, MeLayer);

            if (hit.collider != null)
            {
                Instantiate(Tower,transform.parent.transform.position,Quaternion.identity);
                Destroy(GetComponentInParent<BoatTowerController>().gameObject);
            }
        }
    }
}
