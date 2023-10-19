using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{

    public GameObject ui;
    public TMP_Text upgradeCost;
    public TMP_Text sellAmount;
    public Button upgradeButton;
    private Node target;
    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        upgradeCost.text = "$" + target.towerBlueprint.upgradeCost;
        if (target.towerBlueprint.upgradeCost == 0){
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

}
