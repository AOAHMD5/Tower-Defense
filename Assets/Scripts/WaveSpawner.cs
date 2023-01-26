using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpawnPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdown;
    public Bullet bullet;
    private float countdown = 2f;
   // public Text HighScore;
    private int waveNumber = 0;
     void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

      //  bullet.score = 0;
        countdown -= Time.deltaTime;
       // HighScore.text = bullet.score.ToString();
        waveCountdown.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
       

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
