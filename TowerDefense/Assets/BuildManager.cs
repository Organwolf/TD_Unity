using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    [SerializeField] GameObject standardTurretPrefab;

    private GameObject turretToBuild;

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

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
