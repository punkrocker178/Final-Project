using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    private GameObject turretToBuild;
    public GameObject machineGunTurretPrefab;
    public GameObject rockerTurretPrefab;

    public static BuildController instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject GetTurretBuild()
    {
        return turretToBuild;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
