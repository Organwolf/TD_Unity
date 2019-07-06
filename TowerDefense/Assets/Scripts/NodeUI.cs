using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    private Node target;

    public void SetTarget (Node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        if(target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = true;
        }
        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
	{
        Debug.Log("Trying to upgrade baby!");
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

    public void TestButtons()
    {
        Debug.Log("Button Test");
    }
}
