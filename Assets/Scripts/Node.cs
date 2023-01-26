using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;

    public Vector3 posOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;

    private Color startColour;

    BuildManager buildManager;
     void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }

    //checks to see if we can build turrets on node 
     void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if(turret != null)
        {
            Debug.Log("Cant Build");
            return;
        }

        buildManager.BuildTurretOn(this);
        
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        rend.material.color = hoverColour;
       
    }

     void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
