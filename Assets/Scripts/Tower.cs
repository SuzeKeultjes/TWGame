using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform firePoint;

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
            if (hit.transform.tag == "Enemy")
            {
                Shoot(hit.transform);
            }
        }
    }

    void Shoot(Transform enemy)
    {
       
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}

