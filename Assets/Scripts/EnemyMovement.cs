using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
   private int wavepointIndex = 0;
   private Enemy enemy;
   void Start()
   {
    enemy = GetComponent<Enemy>();
    enemy.speed = enemy.Startspeed;
    target = Waypoints.points[0];
    enemy.health = enemy.startHealth;
   }
   void Update()
   {
    enemy.slowTime -= Time.deltaTime;
    if (enemy.slowTime <= 0)
    {
        enemy.slowTime = 0;
        enemy.speed = enemy.Startspeed;
    }
    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
    transform.rotation = Quaternion.LookRotation (dir);

    if (Vector3.Distance(transform.position, target.position) <= 0.4f)
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
        if (wavepointIndex == 0 && Enemy.confused == true)
        {
            Enemy.confused = false;
            return;
        }
        if (Enemy.confused == true)
        {
            wavepointIndex--;
            target = Waypoints.points[wavepointIndex];
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
