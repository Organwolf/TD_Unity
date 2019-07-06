using UnityEngine;

// unity w save and load the values for us
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount ()
	{
		return (cost/2); 
	}
}
