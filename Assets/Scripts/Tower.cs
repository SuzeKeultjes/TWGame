using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;

    private float fireCountdown;

    void Update()
    {
        if (fireCountdown <= 0f)
        {
            TargetEnemy();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void TargetEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Shoot(hit.transform);
            }
        }
    }

    void Shoot(Transform enemy)
    {
       Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(-6.67999983, 3.99000001, -28.9899998, 1);
    }

}

