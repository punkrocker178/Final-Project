using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildController buildController;

    void Start()
    {
        buildController = BuildController.instance;
    }

    public void BuyMachineGunTurret()
    {
        Debug.Log("Bought with gold");
        buildController.SetTurretToBuild(buildController.machineGunTurretPrefab);
    }

    public void BuyRocketTurret()
    {
        Debug.Log("Bought with golden coin");
        buildController.SetTurretToBuild(buildController.rockerTurretPrefab);
    }
}
