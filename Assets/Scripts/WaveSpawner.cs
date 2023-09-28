using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
  public static int EnemiesAlive = 0;
  public Wave[] waves;
  public TextMeshProUGUI WaveTimer;
  public Transform spawnPoint;
  public GameObject Strtbuttn;

  public float WaveTime = 10f;
  private float countdown = 0f;
  private int waveIndex = 0;
  private bool srtGame;


  void Start()
  {
    srtGame = false;
  }
  void Update ()
  {     
    if (EnemiesAlive > 0)
    {
      return;
    }
    if(srtGame == true){
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = WaveTime;
            return;
        }
        countdown -= Time.deltaTime;

        WaveTimer.text = Mathf.Round(countdown).ToString();
    }
  }

  IEnumerator SpawnWave()
  {

    Wave wave = waves[waveIndex];
    for (int i = 0; i < wave.count; i++)
    {
        SpawnEnemy(wave.enemy);
        yield return new WaitForSeconds(1f / wave.rate);
    }
    waveIndex++;
  }

  void SpawnEnemy(GameObject enemy)
  {
    Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    EnemiesAlive++;
  }

  public void Srtbuttn()
  {
    srtGame = true;
    Strtbuttn.SetActive(false);
  }
}
