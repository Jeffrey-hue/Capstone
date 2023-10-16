using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("Attributes")]
    public float turnSpeed = 10f;
    public float range = 10f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    private Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public bool slow;
    public float slowPct = .5f;
    // Start is called before the first frame update
    void Start()
    {
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
        fireCountDown -= Time.deltaTime;
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
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
}
