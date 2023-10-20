using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
   public GameObject prefab;
   public int cost;
   public GameObject upgradedPrefab;
   public GameObject upgradedTwoPrefab;
   public GameObject upgradedThreePrefab;
   public int upgradeCost;
   public int startUpgradeCost;
   public bool fullyUpgraded = false;
   public int GetSellAmount ()
   {
      return cost / 2;
   }
}

