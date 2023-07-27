using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerS : MonoBehaviour
{
    public int buyTower;
    void Start()
    {
        BoatController.current.gold -= buyTower;
    }
}
