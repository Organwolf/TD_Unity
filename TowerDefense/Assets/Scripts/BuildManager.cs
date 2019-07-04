using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;
    public GameObject missileLauncherPrefab;

    // Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
