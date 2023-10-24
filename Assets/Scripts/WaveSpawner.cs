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
  public int value = 150;

  public float WaveTime = 10f;
  public float countdown = 0f;
  public int waveIndex = 0;
  public bool srtGame;
  public GameManager gameManager;

  void Awake()
  {
    srtGame = false;
    this.enabled = true;
    waveIndex = 0;
    EnemiesAlive = 0;
  }

  void Start()
  {
    Debug.Log("I hate this game");
    srtGame = false;
    this.enabled = true;
    waveIndex = 0;
  }
  void Update ()
  {
    if(this.enabled == false){
      Debug.Log("I hate this game");
    }
    if (EnemiesAlive > 0)
    {
      return;
    }
    if (waveIndex == waves.Length)
      {
        gameManager.WinLevel();
        this.enabled = false;
      }     
    if(srtGame == true){
      if (countdown <= 0)
      {
          Debug.Log("I hate this game");
          StartCoroutine(SpawnWave());
          countdown = WaveTime;
          return;
      }
      countdown -= Time.deltaTime;
      PlayerStats.Money += value;
      WaveTimer.text = Mathf.Round(countdown).ToString();
    }
  }

  IEnumerator SpawnWave()
  {
    PlayerStats.Rounds++;
    Wave wave = waves[waveIndex];
    for (int z = 0; z < wave.enemies.Length; z++)
    {
      for (int i = 0; i < wave.enemies[z].count; i++)
      {
          SpawnEnemy(wave.enemies[z].enemy);
          yield return new WaitForSeconds(1f / wave.rate);
      }
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
