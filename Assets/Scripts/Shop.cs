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
    public Node nodes;
    public bool hideNodes;
    private GameObject node;
    private Renderer[] nodesRend;

    BuildManager buildManager;
    void Start ()
    {
        buildManager = BuildManager.instance;
        GameObject[] node = GameObject.FindGameObjectsWithTag("Node");
        nodesRend = new Renderer[node.Length];
        for (int i = 0; i < nodesRend.Length; i++)
        {
          nodesRend[i] = node[i].GetComponent<Renderer>();
        }
    }
    void Update ()
    {
          if (GameManager.gameEnded){
            this.enabled = false;
            return;
          }
          if (hideNodes == true)
          {
               EnableRenderer(nodesRend, false);
          }
          if (hideNodes == false)
          {
               EnableRenderer(nodesRend, true);
          }
    }
   public void SelectLuffy ()
   {
        Debug.Log("luffy purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Luffy);
   }

   public void SelectZoro ()
   {
        Debug.Log("zoro purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Zoro);
   }

   public void SelectChopper ()
   {
        Debug.Log("chopper purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Chopper);
   }

   public void SelectRobin ()
   {
        Debug.Log("robin purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Robin);
   }

   public void SelectUta ()
   {
        Debug.Log("uta purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Uta);
   }
   void EnableRenderer(Renderer[] rd, bool enable)
{
    for (int i = 0; i < rd.Length; i++)
    {
        rd[i].enabled = enable;
    }
}
}
