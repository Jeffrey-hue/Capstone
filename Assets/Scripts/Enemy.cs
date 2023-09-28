using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Enemy : MonoBehaviour
{
   public float speed = 10f; 
   public int health = 100;
   public int value = 50;
   private Transform target;
   private int wavepointIndex = 0;
   //public Image healthbar;
   //public float health;
   void Start()
   {
    target = Waypoints.points[0];
   }

   public void TakeDamage(int amount)
   {
    health -= amount;

    if (health <= 0)
    {
        Die();
    }
   }

   void Die ()
   {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += value;
        Destroy(gameObject);
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
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
   }
}
