using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    private Color red = Color.red;
    private Color black = Color.black;

    SpriteRenderer sr;
    public GameObject Tower;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.GetComponent<SpriteRenderer>().color = red;
        gameObject.SetActive(false);
    }
    private void OnMouseEnter()
    {
        sr.GetComponent<SpriteRenderer>().color = black;
    }
    private void OnMouseExit()
    {
        sr.GetComponent<SpriteRenderer>().color = red;
    }
    private void OnDisable()
    {
        sr.GetComponent<SpriteRenderer>().color = red;
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

}
