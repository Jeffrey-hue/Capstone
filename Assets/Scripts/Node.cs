using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
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
    void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild == null)
        {
            
            return;
        }
        rend.material.color = hoverColor;
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
