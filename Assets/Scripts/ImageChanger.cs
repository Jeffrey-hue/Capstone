using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Towers;

public class ImageChanger : MonoBehaviour
{
    public Tower Luffy;
    public Tower Zoro;
    public Tower Chopper;
    public Tower Robin;
    public Tower Uta;
    public NodeUi nodeui;
    public AbilitySystem system;
    public Sprite Locked;
    public Sprite LuffyAbility;
    public Sprite ZoroAbility;
    public Sprite ChopperAbility;
    public Sprite RobinAbility;
    public Sprite UtaAbility;
    public bool Llocked;
    public bool Zlocked;
    public bool Clocked;
    public bool Rlocked;
    public bool Ulocked;
    // Start is called before the first frame update
    void Start()
    {
        Llocked = true;
        Zlocked = true;
        Clocked = true;
        Rlocked = true;
        Ulocked = true;
        GetComponent<Image>().sprite = Locked;
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }

    public void FindTarget()
    {
        if (nodeui.target == null)
        {
            return;
        }
        if (nodeui.target.towerBlueprint.name != "Luffy" && nodeui.target.towerBlueprint.name != "Zoro" && nodeui.target.towerBlueprint.name != "Chopper" && nodeui.target.towerBlueprint.name != "Robin" && nodeui.target.towerBlueprint.name != "Uta")
        {
            Debug.Log("yjfas");
            return;
        }
        if (nodeui.target.towerBlueprint.name == "Luffy" && nodeui.target.numOfUpgrades == 3)
        {
            Llocked = false;
            //Luffy = GameObject.FindGameObjectWithTag("Luffy").GetComponent<Tower>();
            system.abilityImage1.GetComponent<Image>().sprite = LuffyAbility;
        }
        if (nodeui.target.towerBlueprint.name == "Zoro" && nodeui.target.numOfUpgrades == 3)
        {
            Zlocked = false;
            //Zoro = GameObject.FindGameObjectWithTag("Zoro").GetComponent<Tower>();
            system.abilityImage2.GetComponent<Image>().sprite = ZoroAbility;
        }

        if (nodeui.target.towerBlueprint.name == "Chopper" && nodeui.target.numOfUpgrades == 3)
        {
            Clocked = false;
            //Chopper = GameObject.FindGameObjectWithTag("Chopper").GetComponent<Tower>();
            system.abilityImage3.GetComponent<Image>().sprite = ChopperAbility;
        }

        if (nodeui.target.towerBlueprint.name == "Robin" && nodeui.target.numOfUpgrades == 3)
        {
            Rlocked = false;
            //Robin = GameObject.FindGameObjectWithTag("Robin").GetComponent<Tower>();
            system.abilityImage4.GetComponent<Image>().sprite = RobinAbility;
        }

        if (nodeui.target.towerBlueprint.name == "Uta" && nodeui.target.numOfUpgrades == 3)
        {
            Ulocked = false;
            //Uta = GameObject.FindGameObjectWithTag("Uta").GetComponent<Tower>();
            system.abilityImage5.GetComponent<Image>().sprite = UtaAbility;
        }
    }
}
