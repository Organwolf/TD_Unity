using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Stand turret selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);

    }
}
