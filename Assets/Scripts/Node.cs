using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer ren;
    private Color startColor;
    private GameObject turret;

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

        if (buildController.GetTurretBuild() == null)
        {
            return;
        }
        
        ren.material.color = hoverColor;
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

        if (buildController.GetTurretBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        GameObject turretToBuild = buildController.GetTurretBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
