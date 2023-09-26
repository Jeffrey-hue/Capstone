using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
  public static int EnemiesAlive = 0;
  public Transform enemyPrefab;
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
    if(srtGame == true){
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = WaveTime;
        }
        countdown -= Time.deltaTime;

        WaveTimer.text = Mathf.Round(countdown).ToString();
    }
  }

  IEnumerator SpawnWave()
  {
    waveIndex++;
    for (int i = 0; i < waveIndex; i++)
    {
        SpawnEnemy();
        yield return new WaitForSeconds(0.5f);
    }
  }

  void SpawnEnemy()
  {
    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    EnemiesAlive++;
  }

  public void Srtbuttn()
  {
    srtGame = true;
    Strtbuttn.SetActive(false);
  }
}
