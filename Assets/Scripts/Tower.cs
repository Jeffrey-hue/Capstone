using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers{
public class Tower : MonoBehaviour
{

    [Header("Attributes")]
    public float turnSpeed = 10f;
    public float range = 10f;
    public float buffedRange;
    public float fireRate = 1f;
    public float buffedRate;
    public float fireCountDown;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public GameObject abilityPrefab;
    public float slowAmount = 1f;
    public float slowTime = 5f;
    public float bleedAmount = 2f;
    public float bleedTime = .5f; 
    public float abilityRadius;
    public float confusedTime;
    public float buffTime;
    public bool buffed;
    public float startRange;
    public float startRate;
    public float ChopperAbilDamage;
    // Start is called before the first frame update
    void Start()
    {
        startRange = range;
        startRate = fireRate;
        //enemy = GetComponent<Enemy>();
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
            //Shoot();
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
        Gizmos.DrawWireSphere(transform.position, abilityRadius);
    }

    public void LuffyAbil()
    {
        Instantiate(abilityPrefab, firepoint.position, firepoint.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, abilityRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Slow(collider.transform);
            }
        }
    }
    public void ZoroAbil()
    {
        Instantiate(abilityPrefab, firepoint.position, firepoint.rotation);
        StartCoroutine(DoBuff());
    }
    public void ChopperAbil()
    {
        Instantiate(abilityPrefab, firepoint.position, firepoint.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, abilityRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    } 
    public void RobinAbil()
    {
        Instantiate(abilityPrefab, firepoint.position, firepoint.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, abilityRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Debug.Log("guasjk");
                Bleed(collider.transform);
            }
        }
    }
    public void UtaAbil()
    {
        Instantiate(abilityPrefab, firepoint.position, firepoint.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, abilityRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Slow(collider.transform);
                Debug.Log("hsfjahsf");
                StartCoroutine(DoConfused());
            }
        }
    }
    IEnumerator DoConfused()
    {
        Enemy.confused = true;
        yield return new WaitForSeconds(confusedTime);
        Debug.Log("reah");
        Enemy.confused = false;
    }
    IEnumerator DoBuff()
    {
        buffed = true;
        range = buffedRange;
        fireRate = buffedRate;
        yield return new WaitForSeconds(buffTime);
        Debug.Log("jhkajhsf");
        range = startRange;
        fireRate = startRate;
        buffed = false;
    }
    void Slow (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.Slow(slowAmount, slowTime);
        }
    }
    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(ChopperAbilDamage);
        }
    }
    void Bleed (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.Bleed(bleedAmount, bleedTime);
        }
    }
}
}
