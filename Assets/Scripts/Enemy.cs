using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public float speed;
   public float Startspeed = 10f; 
   public int startHealth = 100;
   public float health;
   public int value = 50;
   public Image healthbar;
   public float slowTime = 2;

   public void TakeDamage(float amount)
   {
    health -= amount;

    healthbar.fillAmount = health / startHealth;

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
   public void Slow(float amount, float time)
    {
        slowTime = time;
        if (slowTime > 0)
        {
            Debug.Log("GRRRR");
            speed = Startspeed * (1f - amount);
        }
    } 
   
}
