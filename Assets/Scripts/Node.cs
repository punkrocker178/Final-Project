using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer ren;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;

    BuildController buildController;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        startColor = ren.material.color;
        buildController = BuildController.instance;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildController.CanBuild())
        {
            return;
        }
        
       if (!buildController.HasMoney())
        {
            ren.material.color = Color.red;
        } else
        {
            ren.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        ren.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildController.SelectNode(this);
            return;
        }

         if (!buildController.CanBuild())
        {
            return;
        }

        BuildTurret(buildController.GetTurretToBuild());
    }

    public void BuildTurret(TurretBlueprint turretBlueprint) {
        if (PlayerStats.Money < turretBlueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        } else
        {
            PlayerStats.Money -= turretBlueprint.cost;
        }

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        this.turretBlueprint = turretBlueprint;
    }

    public void UpgradeTurret() {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        } else
        {
            PlayerStats.Money -= turretBlueprint.upgradeCost;
        }

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        isUpgraded = true;
    }

    public void SellTurret() {
        PlayerStats.Money += (int) turretBlueprint.GetSellCost();
        Destroy(turret);
        turret = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

}
