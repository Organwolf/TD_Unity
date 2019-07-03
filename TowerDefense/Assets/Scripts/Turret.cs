using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // finding a taget
    // rotating towards target

    private Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] Transform partToRotate;

    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        // invoke a function to repeat it 0.5 seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        // rotate stuff
        Vector3 

    }

    // a unity callback function
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // search for targets at a fixed basis
    // so we don't have to update targets every frame
    void UpdateTarget()
    {
        // array of enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }

    }
}
