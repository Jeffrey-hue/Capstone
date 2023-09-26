using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 targetPosition;
    private Transform Target;
    public float speed = 70f;
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
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        if (effectIns != null){
            Destroy(effectIns, 2f);
            Destroy(Target.gameObject);
            Destroy(gameObject);
        }
        
    }

}
