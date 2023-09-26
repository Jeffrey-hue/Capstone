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

    public GameObject standardTurretPrefab;
    void Start ()
    {
        turretToBuild = standardTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretTOBuild ()
    {
        return turretToBuild;
    }
}
