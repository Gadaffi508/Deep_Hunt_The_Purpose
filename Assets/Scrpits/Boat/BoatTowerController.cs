using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatTowerController : MonoBehaviour
{
    public GameObject[] tower;
    private GameObject kareObj;

    void Start()
    {
        kareObj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        foreach (GameObject circle in tower)
        {
            circle.SetActive(true);
            if (Input.GetMouseButtonDown(0) && circle == EventSystem.current.currentSelectedGameObject)
            {
                // Alt objenin konumunu kare objesine eþitleyin
                kareObj.transform.position = circle.transform.position;

                // Alt objeyi etkisiz hale getirin
                circle.SetActive(false);
            }
        }

    }
}

