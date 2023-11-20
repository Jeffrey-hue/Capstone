using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Towers;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake ()
    {   
        if (instance != null)
        {
            Debug.Log("more than one BuildManager");
            return;
        }
        instance = this;
        
    }
    public GameObject Luffy;
    public GameObject Zoro;
    public GameObject Chopper;
    public GameObject Robin;
    public GameObject Uta;
    public NodeUi nodeUI;
    public Shop shop;
    private TowerBlueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild {get {return this.turretToBuild.prefab != null;}}
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost;}}
    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild (TowerBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TowerBlueprint GetTurretToBuild ()
    {
        /*shop.ui.rangeIndicator.SetActive(true);
        shop.ui.rangeIndicator.transform.position = selectedNode.GetBuildPosition();
        shop.ui.rangeIndicator.transform.localScale = new Vector3(selectedNode.turret.GetComponent<Tower>().range, 1, selectedNode.turret.GetComponent<Tower>().range);*/
        return turretToBuild;
    }
}
