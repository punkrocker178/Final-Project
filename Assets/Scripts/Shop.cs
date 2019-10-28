using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildController buildController;
    public TurretBlueprint machineTurret;
    public TurretBlueprint rocketTurret;

    void Start()
    {
        buildController = BuildController.instance;
    }

    public void BuyMachineGunTurret()
    {
        Debug.Log("Bought with gold");
        buildController.SelectTurret(machineTurret);
    }

    public void BuyRocketTurret()
    {
        Debug.Log("Bought with golden coin");
        buildController.SelectTurret(rocketTurret);
    }
}
