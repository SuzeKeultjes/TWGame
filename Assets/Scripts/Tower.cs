using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public LayerMask layer;

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
        //RaycastHit hit;
        //if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        //{
        //    if (hit.transform.CompareTag("Enemy"))
        //    {
        //        Shoot(hit.transform);
        //    }
        //}

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f, layer);
        
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name);
            hitCollider.gameObject.SetActive(true);
            //hitCollider.SendMessage("AddDamage");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }

    void Shoot(Transform enemy)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

    }    
}


