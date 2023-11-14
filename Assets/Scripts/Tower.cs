using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers{
public class Tower : MonoBehaviour
{

    [Header("Attributes")]
    public float turnSpeed = 10f;
    public float range = 10f;
    public float fireRate = 1f;
    public float fireCountDown;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public GameObject abilityPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        fireCountDown -= Time.deltaTime;
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        } 

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else {
            target = null;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        if (fireCountDown > 0)
        {
            fireCountDown -= Time.deltaTime;
        }
        if(target == null)
        {
            return;
        }
        LockOnTarget();
        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown += fireRate;
        }
        if (fireCountDown < 0)
        {
            fireCountDown = 0;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot ()
    {
        GameObject projectileGO = (GameObject)Instantiate (bulletPrefab, firepoint.position, firepoint.rotation);
        Projectile bullet = projectileGO.GetComponent<Projectile>(); 

        if (bullet != null)
        {
           bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void LuffyAbil()
    {
        
        GameObject projectileGO = (GameObject)Instantiate (abilityPrefab, firepoint.position, firepoint.rotation);
        Projectile bullet = projectileGO.GetComponent<Projectile>(); 
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
}
