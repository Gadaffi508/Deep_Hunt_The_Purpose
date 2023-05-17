using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : BoatTowerController
{
    public GameObject[] Tower;

    public override void CloseTower()
    {
        foreach (GameObject tower in Tower)
        {
            tower.SetActive(false);
        }
    }

    public override void TowerBuilt()
    {
        foreach (GameObject tower in Tower)
        {
            tower.SetActive(true);
        }
    }
}
