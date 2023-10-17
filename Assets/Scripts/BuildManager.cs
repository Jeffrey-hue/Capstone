using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return turretToBuild;
    }
}
