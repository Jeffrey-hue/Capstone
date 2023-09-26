using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed = 10f; 
   private Transform target;
   private int wavepointIndex = 0;
   void Start()
   {
    target = Waypoints.points[0];
   }

   void Update()
   {
    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    transform.rotation = Quaternion.LookRotation (dir);

    if (Vector3.Distance(transform.position, target.position) <= 0.2f)
    {
        GetNextWaypoints();
    }

    void GetNextWaypoints()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    /*void Health(){
        ui = GameObject.FindObjectOfType<EnemyUI> ();
    }*/
   }
}
