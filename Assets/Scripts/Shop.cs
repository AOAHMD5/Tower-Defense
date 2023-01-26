using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

     void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Select Turrets Method // can add more turrets in the future 
    public void SelectStandardTurret()
    {
        Debug.Log("Selected Standard Turret");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Selected Standard Missile Turret");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}

