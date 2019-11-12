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

        BuildTurret(buildController.GetTurretToBuild ());
    }

        void BuildTurret(TurretBlueprint blueprint) {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        } else
        {
            PlayerStats.Money -= blueprint.cost;
        }

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
