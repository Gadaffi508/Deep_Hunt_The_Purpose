using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : BoatTowerController
{
    public GameObject tower;
    public override void CloseTower()
    {
        
    }

    public override void TowerBuilt()
    {
        Instantiate(tower,transform.parent.transform.position,Quaternion.identity);
        Destroy(GetComponentInParent<tower>().gameObject);
    }
}

