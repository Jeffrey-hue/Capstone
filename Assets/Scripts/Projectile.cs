using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
    private Vector3 targetPosition;
    private Transform Target;
    public float speed = 70f;
    public float ExplosionRadius = 0f;
    public GameObject impactEffect;
    public bool slow;
    public bool bleed;
    public bool ability;
    public float slowAmount = .2f;
    public float slowTime = 2f;
    public float bleedAmount = 2f;
    public float bleedTime = .5f;
    public float abilityTime;
    public int damage;
    public void Seek(Transform _target)
    {
        targetPosition= _target.position;
        Target = _target;
    }
    void Update ()
    {
        if(Target == null && ability == false){
            Destroy(gameObject);
            return;
        }

        if(ability == true)
        {
            StartCoroutine(DoAbility(abilityTime));
        }

        Vector3 dir = targetPosition - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            if(slow == true)
            {
                Debug.Log("uh");
                Slow(Target);
            }
            if(bleed == true)
            {
                Debug.Log("ouch");
                Bleed(Target);
            }
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(Target);
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(Target);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Slow (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.Slow(slowAmount, slowTime);
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

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected (){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
    IEnumerator DoAbility(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
