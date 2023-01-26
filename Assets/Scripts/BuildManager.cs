using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public Text Money;

     void Update()
    {
        Money.text = " Money "  + PlayerStats.Money.ToString();
    }

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one Build");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    public GameObject MissileTurret;


    private TurretBlueprint turretToBuild;

    //property to see if node is not equal to null 
   public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

       GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build! Money Left" + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
