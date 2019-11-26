using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public Text upgradeCost;
    public Text sellCost;
	public Button upgradeButton;

    public void SetTarget(Node target) {
        this.target = target;
        transform.position = target.GetBuildPosition();

        if (!this.target.isUpgraded)
		{
			upgradeCost.text = "UPGRADE" + "\n$" + this.target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		} else
		{
			upgradeCost.text = "UPGRADED";
			upgradeButton.interactable = false;
		}
        
        sellCost.text = "SELL" + "\n$" + this.target.turretBlueprint.GetSellCost();
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        this.target.UpgradeTurret();
        BuildController.instance.DeselectNode();
    }

    public void Sell() {
        this.target.SellTurret();
        BuildController.instance.DeselectNode();
    }
}
