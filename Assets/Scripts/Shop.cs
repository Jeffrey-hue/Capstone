using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint Luffy;
    public TowerBlueprint Zoro;
    public TowerBlueprint Chopper;
    public TowerBlueprint Robin;
    public TowerBlueprint Uta;

    BuildManager buildManager;
    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    void Update ()
    {
          if (GameManager.gameEnded){
            this.enabled = false;
            return;
          }
    }
   public void SelectLuffy ()
   {
        Debug.Log("luffy purchased");
        buildManager.SelectTurretToBuild(Luffy);
   }

   public void SelectZoro ()
   {
        Debug.Log("zoro purchased");
        buildManager.SelectTurretToBuild(Zoro);
   }

   public void SelectChopper ()
   {
        Debug.Log("chopper purchased");
        buildManager.SelectTurretToBuild(Chopper);
   }

   public void SelectRobin ()
   {
        Debug.Log("robin purchased");
        buildManager.SelectTurretToBuild(Robin);
   }

   public void SelectUta ()
   {
        Debug.Log("uta purchased");
        buildManager.SelectTurretToBuild(Uta);
   }
}
