using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject Tower;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    private void OnMouseEnter()
    {
        sr.color = Color.black;
    }
    private void OnMouseExit()
    {
        sr.color = Color.red;
    }
    private void OnMouseDown()
    {
        GameObject[] circles = GameObject.FindGameObjectsWithTag("kule");
        foreach (var circle in circles)
        {
            Destroy(circle);
        }
        Instantiate(Tower, transform.parent.transform.position, Quaternion.identity);
        
    }
    private void OnDisable()
    {
        sr.color = Color.red;
    }

}
