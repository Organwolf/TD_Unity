using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    public Transform spawnPoint;
    public Text waveCountdownTex;

    private float countdown = 2f;
    private int waveIndex = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownTex.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
