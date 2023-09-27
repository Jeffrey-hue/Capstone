using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 targetPosition;
    private Transform Target;
    public float speed = 70f;
    public float ExplosionRadius = 0f;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        targetPosition= _target.position;
        Target = _target;
    }
 // Update is called once per frame

 void Update ()
    {
        if(Target == null){
            Destroy(gameObject);
            return;
        }
        Vector3 dir = targetPosition - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
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

    void Damage (Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected (){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }

}
