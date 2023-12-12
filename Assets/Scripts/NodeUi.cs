using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using Towers;

public class NodeUi : MonoBehaviour
{
    /*[Header("Images")]
    public Image Lability;
    public Image Zability;
    public Image Cability;
    public Image Rability;
    public Image Uability;*/
    [Header("UI")]
    public GameObject ui;
    //public Tower Luffy;
    //public Tower Zoro;
    //public Tower Chopper;
    //public Tower Robin;
    //public Tower Uta;

    public TMP_Text upgradeCost;
    public TMP_Text sellAmount;
    public Button upgradeButton;
    public Node target;
    public GameObject rangeIndicator;
    //public GameObject LuffyAbility;
    //public GameObject ZoroAbility;
    //public GameObject ChopperAbility;
    //public GameObject RobinAbility;
    //public GameObject UtaAbility;
    //public GameObject Locked;
    /*void Update()
    {
        /*LabilityTime -= Time.deltaTime;
        ZabilityTime -= Time.deltaTime;
        CabilityTime -= Time.deltaTime;
        RabilityTime -= Time.deltaTime;
        UabilityTime -= Time.deltaTime; 
        Lability.fillAmount = LabilityTime / LcoolDown;
        Zability.fillAmount = ZabilityTime / ZcoolDown;
        Cability.fillAmount = CabilityTime / CcoolDown;
        Rability.fillAmount = RabilityTime / RcoolDown;
        Uability.fillAmount = UabilityTime / UcoolDown;*/

        /*if (target.towerBlueprint.name == "Luffy" && target.numOfUpgrades == 3){
            Luffy = GetComponents<>();
            LuffyAbility.SetActive(true);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Zoro" && target.numOfUpgrades == 3){
            //Zoro = GameObject.FindGameObjectWithTag("Zoro").GetComponent<Tower>();
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(true);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Chopper" && target.numOfUpgrades == 3){
            //Chopper = GameObject.FindGameObjectWithTag("Chopper").GetComponent<Tower>();
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(true);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Robin" && target.numOfUpgrades == 3){
            //Robin = GameObject.FindGameObjectWithTag("Robin").GetComponent<Tower>();
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(true);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Uta" && target.numOfUpgrades == 3){
            //Uta = GameObject.FindGameObjectWithTag("Uta").GetComponent<Tower>();
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(true);
            Locked.SetActive(false);
        }
        if (target.numOfUpgrades < 2)
        {
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(true);
        }
    }*/

    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        rangeIndicator.SetActive(true);
        rangeIndicator.transform.position = target.GetBuildPosition();
        rangeIndicator.transform.localScale = new Vector3(target.turret.GetComponent<Tower>().range, 4, target.turret.GetComponent<Tower>().range);

        upgradeCost.text = "" + target.towerBlueprint.upgradeCost;
        /*if(Luffy != null)
        {
            Luffy = null;
        }
        if (target.towerBlueprint.name == "Luffy" && target.numOfUpgrades == 3)
        {
            //Luffy = GameObject.FindGameObjectWithTag("Luffy").GetComponent<Tower>();
        }*/
        if(target.numOfUpgrades == 0)
        {
            target.towerBlueprint.fullyUpgraded = false;
        }
        if (target.towerBlueprint.fullyUpgraded == true){
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false;
        } else
        {
            upgradeButton.interactable = true;
        }
        sellAmount.text = "" + target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
        rangeIndicator.SetActive(false);
    }

    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell ()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

    /*[Header("Ability Cooldowns")]
    public float LcoolDown;
    public float LabilityTime;
    public float ZcoolDown;
    private float ZabilityTime;
    public float CcoolDown;
    private float CabilityTime;
    public float RcoolDown;
    private float RabilityTime;
    public float UcoolDown;
    private float UabilityTime;
    public void LAbility()
    {
        if(LabilityTime <= 0f)
        {
            Luffy.LuffyAbil();
            LabilityTime = LcoolDown; 
        }
    }

    public void ZAbility()
    {
        if(ZabilityTime <= 0f)
        {
            Zoro.ZoroAbil();
            ZabilityTime = ZcoolDown; 
        }
    }

    public void CAbility()
    {
        if(CabilityTime <= 0f)
        {
            Chopper.ChopperAbil();
            CabilityTime = CcoolDown; 
        }
    }

    public void RAbility()
    {
        if(RabilityTime <= 0f)
        {
            Robin.RobinAbil();
            RabilityTime = RcoolDown; 
        }
    }

    public void UAbility()
    {
        if(UabilityTime <= 0f)
        {
            Uta.UtaAbil();
            UabilityTime = UcoolDown; 
        }
    }*/
}
