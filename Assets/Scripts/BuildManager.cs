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
    private TowerBlueprint turretToBuild;

    public bool CanBuild {get {return this.turretToBuild.prefab != null;}}
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost;}}


    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Add Notif to player");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret built money left: " + PlayerStats.Money);
    }
    public void SelectTurretToBuild (TowerBlueprint turret)
    {
        turretToBuild = turret;
    }
}
