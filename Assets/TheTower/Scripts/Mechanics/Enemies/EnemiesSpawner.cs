using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesSpawner 
{
    private Waves Waves;
    private Tower Tower;
    private EnemiesFactory EnemiesFactory;
    private float Timer;
    private float radius = 14;
    //private WaveEnemies WaveEnemies;
    //public int AmountEnemyInWave = 10;
    private int WaveIndex = 0;

    public EnemiesSpawner(Tower tower, EnemiesFactory enemiesFactory, Waves waves)
    {
        Tower = tower;
        EnemiesFactory = enemiesFactory;
        Waves = waves;
    }

    public void WavesSpawn()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (Waves.waveSettings[WaveIndex].AmountEnemies > 0) 
            {
                Timer = Random.Range(0.1f, 0.7f);
                Spawn();
                Waves.waveSettings[WaveIndex].AmountEnemies--;
            }
 
            if (Waves.waveSettings[WaveIndex].AmountEnemies == 0)
            {
                if (EnemiesFactory.enemies.Count == 0)
                {
                    WaveIndex++;
                    Debug.Log(WaveIndex);
                }
            }
        }
    }

    private void Spawn()
    {
        //EnemiesFactory.enemies.

        var randomVector2 = Random.insideUnitCircle.normalized;
        var randomVector3 = new Vector3(randomVector2.x, 0.0f, randomVector2.y);
        var spawnPoint = randomVector3 * Random.Range(radius - 2, radius + 2) + Tower.transform.position;

        var enemy = EnemiesFactory.Spawn(spawnPoint, Quaternion.identity);
        enemy.SetTarget(Tower.transform);
    }
}
