using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class NodeUi : MonoBehaviour
{

    public GameObject ui;
    public TMP_Text upgradeCost;
    public TMP_Text sellAmount;
    public Button upgradeButton;
    private Node target;
    public GameObject LuffyAbility;
    public GameObject ZoroAbility;
    public GameObject ChopperAbility;
    public GameObject RobinAbility;
    public GameObject UtaAbility;
    public GameObject Locked;
    void Update()
    {
        LabilityTime -= Time.deltaTime;
        ZabilityTime -= Time.deltaTime;
        CabilityTime -= Time.deltaTime;
        RabilityTime -= Time.deltaTime;
        UabilityTime -= Time.deltaTime; 
        if (target.towerBlueprint.name == "Luffy" && target.numOfUpgrades >= 2){
            LuffyAbility.SetActive(true);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Zoro" && target.numOfUpgrades >= 2){
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(true);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Chopper" && target.numOfUpgrades >= 2){
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(true);
            RobinAbility.SetActive(false);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Robin" && target.numOfUpgrades >= 2){
            LuffyAbility.SetActive(false);
            ZoroAbility.SetActive(false);
            ChopperAbility.SetActive(false);
            RobinAbility.SetActive(true);
            UtaAbility.SetActive(false);
            Locked.SetActive(false);
        }

        if (target.towerBlueprint.name == "Uta" && target.numOfUpgrades >= 2){
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
    }

    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        upgradeCost.text = "$" + target.towerBlueprint.upgradeCost;
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
        sellAmount.text = "$" + target.towerBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
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

    public float LcoolDown;
    private float LabilityTime;
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
            Debug.Log("Ability");
            LabilityTime = LcoolDown; 
        }
    }

    public void ZAbility()
    {
        if(ZabilityTime <= 0f)
        {
            Debug.Log("Ability");
            ZabilityTime = ZcoolDown; 
        }
    }

    public void CAbility()
    {
        if(CabilityTime <= 0f)
        {
            Debug.Log("Ability");
            CabilityTime = CcoolDown; 
        }
    }

    public void RAbility()
    {
        if(RabilityTime <= 0f)
        {
            Debug.Log("Ability");
            RabilityTime = RcoolDown; 
        }
    }

    public void UAbility()
    {
        if(UabilityTime <= 0f)
        {
            Debug.Log("Ability");
            UabilityTime = UcoolDown; 
        }
    }

}
