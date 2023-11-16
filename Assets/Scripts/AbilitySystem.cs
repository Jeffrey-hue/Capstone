using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Towers;

public class AbilitySystem : MonoBehaviour
{
    [Header("Luffy")]
    public Image abilityImage1;
    public float cooldown1 = 3f;
    bool isCooldown = false;

    [Header("Zoro")]
    public Image abilityImage2;
    public float cooldown2 = 5f;
    bool isCooldown2 = false;

    [Header("Chopper")]
    public Image abilityImage3;
    public float cooldown3 = 10f;
    bool isCooldown3 = false;

    [Header("Robin")]
    public Image abilityImage4;
    public float cooldown4 = 10f;
    bool isCooldown4 = false;

    [Header("Uta")]
    public Image abilityImage5;
    public float cooldown5 = 10f;
    bool isCooldown5 = false;

    [Header("Unity Implementation")]
    public Tower Luffy;
    public Tower Zoro;
    public Tower Chopper;
    public Tower Robin;
    public Tower Uta;
    public Sprite Locked;
    public Sprite LuffyAbility;
    public Sprite ZoroAbility;
    public Sprite ChopperAbility;
    public Sprite RobinAbility;
    public Sprite UtaAbility;
    public ImageChanger changer;

    void Start()
    {
        Button luffybttn = abilityImage1.GetComponent<Button>();
        luffybttn.interactable = false;
        Button zorobttn = abilityImage2.GetComponent<Button>();
        zorobttn.interactable = false;
        Button chopperbttn = abilityImage3.GetComponent<Button>();
        chopperbttn.interactable = false;
        Button robinbttn = abilityImage4.GetComponent<Button>();
        robinbttn.interactable = false;
        Button utabttn = abilityImage5.GetComponent<Button>();
        utabttn.interactable = false;
        abilityImage1.fillAmount = 1;
        abilityImage2.fillAmount = 1;
        abilityImage3.fillAmount = 1;
    }

    void Update()
    {
        if (changer.Llocked == false)
        {
            Button luffybttn = abilityImage1.GetComponent<Button>();
            luffybttn.interactable = true;
        }
        if (changer.Zlocked == false)
        {
            Button zorobttn = abilityImage2.GetComponent<Button>();
            zorobttn.interactable = true;
        }
        if (changer.Clocked == false)
        {
            Button chopperbttn = abilityImage3.GetComponent<Button>();
            chopperbttn.interactable = true;
        }
        if (changer.Rlocked == false)
        {
            Button robinbttn = abilityImage4.GetComponent<Button>();
            robinbttn.interactable = true;
        }
        if (changer.Ulocked == false)
        {
            Button utabttn = abilityImage5.GetComponent<Button>();
            utabttn.interactable = true;
        }
        //Ability1
        if(isCooldown == true)
        {
            abilityImage1.fillAmount += 1 / cooldown1 * Time.deltaTime;
        }

        if(abilityImage1.fillAmount == 1)
        {
            isCooldown = false;
        }

        //Ability2
        if (isCooldown2 == true)
        {
            abilityImage2.fillAmount += 1 / cooldown2 * Time.deltaTime;
        }

        if (abilityImage2.fillAmount == 1)
        {
            isCooldown2 = false;
        }

        //Ability3
        if (isCooldown3 == true)
        {
            abilityImage3.fillAmount += 1 / cooldown3 * Time.deltaTime;
        }

        if (abilityImage3.fillAmount == 1)
        {
            isCooldown3 = false;
        }

        //Ability4
        if (isCooldown4 == true)
        {
            abilityImage4.fillAmount += 1 / cooldown4 * Time.deltaTime;
        }

        if (abilityImage4.fillAmount == 1)
        {
            isCooldown4 = false;
        }

        //Ability5
        if (isCooldown5 == true)
        {
            abilityImage5.fillAmount += 1 / cooldown5 * Time.deltaTime;
        }

        if (abilityImage5.fillAmount == 1)
        {
            isCooldown5 = false;
        }
    }

    public void Ability1()
    {
        if(isCooldown == true)
        {
            Debug.Log("Cooldown!");
        }
        else
        {
            changer.Luffy.LuffyAbil();    
            isCooldown = true;
            abilityImage1.fillAmount = 0;
        }
    }

    public void Ability2()
    {
        if (isCooldown2 == true)
        {
            Debug.Log("Cooldown!");
        }
        else
        {
            changer.Zoro.ZoroAbil();   
            isCooldown2 = true;
            abilityImage2.fillAmount = 0;
        }
    }

    public void Ability3()
    {
        if (isCooldown3 == true)
        {
            Debug.Log("Cooldown!");
        }
        else
        {
            changer.Chopper.ChopperAbil();    
            isCooldown3 = true;
            abilityImage3.fillAmount = 0;
        }
    }

    public void Ability4()
    {
        if (isCooldown4 == true)
        {
            Debug.Log("Cooldown!");
        }
        else
        {
            Debug.Log("ability");
            changer.Robin.RobinAbil();    
            isCooldown4 = true;
            abilityImage4.fillAmount = 0;
        }
    }

    public void Ability5()
    {
        if (isCooldown5 == true)
        {
            Debug.Log("Cooldown!");
        }
        else
        {
            changer.Uta.UtaAbil();   
            isCooldown5 = true;
            abilityImage5.fillAmount = 0;
        }
    }
}
