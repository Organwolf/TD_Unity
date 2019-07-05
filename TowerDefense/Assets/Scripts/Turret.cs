using System;
using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("General")]

    [SerializeField] float range = 15f;

    [Header("Use Bullets (default)")]

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 1f;
    private float fireCountdown = 2f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]

    [SerializeField] string enemyTag = "Enemy";

    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform partToRotate;

    [SerializeField] Transform firePoint;

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
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }

        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        /* Rotate around partToRotates y-axis with Lerp smoothing */
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser ()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        // sets two points in the linerenderer array
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
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
