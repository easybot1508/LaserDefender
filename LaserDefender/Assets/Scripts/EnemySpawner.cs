using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves= 0f;
    [SerializeField] bool isLoop = true;
    WaveConfigSO currentWave;
    
    
    void Start()
    {
        StartCoroutine(SpawnerEnemy());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

   

    IEnumerator SpawnerEnemy()
    {
        do
        {
            foreach (WaveConfigSO waves in waveConfigs)
            {
                currentWave = waves;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLoop); 
    }  
}
