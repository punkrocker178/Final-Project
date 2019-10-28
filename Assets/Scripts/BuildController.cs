using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    private TurretBlueprint turretToBuild;

    public static BuildController instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SelectTurret(TurretBlueprint blueprint)
    {
        turretToBuild = blueprint;
    }

    public bool CanBuild()
    {
        return turretToBuild != null;
    }

    public bool HasMoney()
    {
        return PlayerStats.Money >= turretToBuild.cost;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        } else
        {
            PlayerStats.Money -= turretToBuild.cost;
        }

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition() + node.positionOffset, Quaternion.identity);
        node.turret = turret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
