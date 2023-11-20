using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Towers;
using TMPro;

public class Shop : MonoBehaviour
{
     [Header("Blueprints")]
    public TowerBlueprint Luffy;
    public TowerBlueprint Zoro;
    public TowerBlueprint Chopper;
    public TowerBlueprint Robin;
    public TowerBlueprint Uta;
    [Header("Unity stuff")]
    public Node nodes;
    public NodeUi ui;
    public bool hideNodes;
    private GameObject node;
    private Renderer[] nodesRend;
    [Header("Unity Damage")]
    public int LuffyD;
    public int ZoroD;
    public int ChopperD;
    public int RobinD;
    public int UtaD;
    [Header("Unity Range")]
    public int LuffyR;
    public float ZoroR;
    public int ChopperR;
    public int RobinR;
    public int UtaR;
    [Header("Unity FireRate")]
    public float LuffyFR;
    public float ZoroFR;
    public float ChopperFR;
    public float RobinFR;
    public float UtaFR;
    [Header("Desc")]
    public GameObject LuffyDesc;
    public GameObject ZoroDesc;
    public GameObject ChopperDesc;
    public GameObject RobinDesc;
    public GameObject UtaDesc;
    [Header("Damage")]
    public TextMeshProUGUI LuffyDamage;
    public TextMeshProUGUI ZoroDamage;
    public TextMeshProUGUI ChopperDamage;
    public TextMeshProUGUI RobinDamage;
    public TextMeshProUGUI UtaDamage;
    [Header("FireRate")]
    public TextMeshProUGUI LuffyFireRate;
    public TextMeshProUGUI ZoroFireRate;
    public TextMeshProUGUI ChopperFireRate;
    public TextMeshProUGUI RobinFireRate;
    public TextMeshProUGUI UtaFireRate;
    [Header("Range")]
    public TextMeshProUGUI LuffyRange;
    public TextMeshProUGUI ZoroRange;
    public TextMeshProUGUI ChopperRange;
    public TextMeshProUGUI RobinRange;
    public TextMeshProUGUI UtaRange;

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
        LuffyDamage.text = "Damage: " + LuffyD;
        ZoroDamage.text = "Damage: " + ZoroD;
        ChopperDamage.text = "Damage: " + ChopperD;
        RobinDamage.text = "Damage: " + RobinD;
        UtaDamage.text = "Damage: " + UtaD;

        LuffyFireRate.text = "Fire Rate: " + LuffyFR;
        ZoroFireRate.text = "Fire Rate: " + ZoroFR;
        ChopperFireRate.text = "Fire Rate: " + ChopperFR;
        RobinFireRate.text = "Fire Rate: " + RobinFR;
        UtaFireRate.text = "Fire Rate: " + UtaFR;

        LuffyRange.text = "Range: " + LuffyR;
        ZoroRange.text = "Range: " + ZoroR;
        ChopperRange.text = "Range: " + ChopperR;
        RobinRange.text = "Range: " + RobinR;
        UtaRange.text = "Range: " + UtaR;
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
        LuffyDesc.SetActive(true);
        ZoroDesc.SetActive(false);
        ChopperDesc.SetActive(false);
        RobinDesc.SetActive(false);
        UtaDesc.SetActive(false);
        Debug.Log("luffy purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Luffy);
   }

   public void SelectZoro ()
   {
        ZoroDesc.SetActive(true);
        LuffyDesc.SetActive(false);
        ChopperDesc.SetActive(false);
        RobinDesc.SetActive(false);
        UtaDesc.SetActive(false);
        Debug.Log("zoro purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Zoro);
   }

   public void SelectChopper ()
   {
        ChopperDesc.SetActive(true);
        ZoroDesc.SetActive(false);
        LuffyDesc.SetActive(false);
        RobinDesc.SetActive(false);
        UtaDesc.SetActive(false);
        Debug.Log("chopper purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Chopper);
   }

   public void SelectRobin ()
   {
        RobinDesc.SetActive(true);
        ZoroDesc.SetActive(false);
        ChopperDesc.SetActive(false);
        LuffyDesc.SetActive(false);
        UtaDesc.SetActive(false);
        Debug.Log("robin purchased");
        hideNodes = false;
        buildManager.SelectTurretToBuild(Robin);
   }

   public void SelectUta ()
   {
        UtaDesc.SetActive(true);
        ZoroDesc.SetActive(false);
        ChopperDesc.SetActive(false);
        RobinDesc.SetActive(false);
        LuffyDesc.SetActive(false);
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
