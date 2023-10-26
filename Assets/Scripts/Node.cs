using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Shop shop;
    public Color noMoneyColor;
    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    public TowerBlueprint towerBlueprint;
    public int numOfUpgrades;
    public Renderer rend;
    public Color startColor;
    BuildManager buildManager;

    /*void Awake ()
    {
        //buildManager = BuildManager.instance;
    }*/
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret (TowerBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Add Notif to player");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        towerBlueprint = blueprint;
        Debug.Log("Turret built money left: " + PlayerStats.Money);
        shop.hideNodes = true;
    }

    public void UpgradeTurret ()
    {
        if (numOfUpgrades == 0)
        {
            towerBlueprint.upgradeCost = towerBlueprint.upgradeCost * 1;
        }
        if (PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("Add Notif to player. Upgrade");
            return;
        }
        numOfUpgrades ++;
        if (numOfUpgrades < 4){
            //get rid of old turret
            Destroy(turret);
        }
        if (numOfUpgrades == 1){
            towerBlueprint.upgradeCost = towerBlueprint.startUpgradeCost * 2;
            PlayerStats.Money -= towerBlueprint.upgradeCost;
            GameObject _turret = (GameObject)Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            Debug.Log("Turret built money left: " + PlayerStats.Money);
        }
        if (numOfUpgrades == 2){
            towerBlueprint.upgradeCost = towerBlueprint.startUpgradeCost * 3;
            PlayerStats.Money -= towerBlueprint.upgradeCost;
            GameObject _turret = (GameObject)Instantiate(towerBlueprint.upgradedTwoPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            Debug.Log("Turret built money left: " + PlayerStats.Money);
        }
        if (numOfUpgrades == 3){
            towerBlueprint.upgradeCost = towerBlueprint.startUpgradeCost * 4;
            PlayerStats.Money -= towerBlueprint.upgradeCost;
            GameObject _turret = (GameObject)Instantiate(towerBlueprint.upgradedThreePrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            Debug.Log("Turret built money left: " + PlayerStats.Money);
            towerBlueprint.fullyUpgraded = true;
            towerBlueprint.upgradeCost = towerBlueprint.upgradeCost * 1;
            Debug.Log("Fully Upgraded");
        }
        if (numOfUpgrades >= 4){
            Debug.Log("Fully Upgraded");
            return;
        }
        Debug.Log("Turret upgraded");
    }

    public void SellTurret()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();
        Destroy(turret);
        towerBlueprint = null;
    }

    public void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //if (!buildManager.CanBuild == null)
        //{  
            //return;
        //}
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    
}
