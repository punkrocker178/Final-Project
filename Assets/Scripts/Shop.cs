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
        Debug.Log("Select machine gun");
        buildController.SelectTurret(machineTurret);
    }

    public void BuyRocketTurret()
    {
        Debug.Log("Select rocket");
        buildController.SelectTurret(rocketTurret);
    }
}
