using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color noMoneyColor;
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Awake ()
    {
        buildManager = BuildManager.instance;
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown ()
    {
        if (!buildManager.CanBuild == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("placed");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    public void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild == null)
        {  
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }
}
