using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public static BuildController instance;
    public NodeUI nodeUI;

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
        DeselectNode();
    }

    public void SelectNode (Node node) {

        if (selectedNode == node) {
            DeselectNode();
            return;            
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public bool CanBuild()
    {
        return turretToBuild != null;
    }

    public bool HasMoney()
    {
        return PlayerStats.Money >= turretToBuild.cost;
    }

    public TurretBlueprint GetTurretToBuild () {
        return turretToBuild;
    }
}
