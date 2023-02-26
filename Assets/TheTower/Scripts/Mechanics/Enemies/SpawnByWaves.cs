
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByWaves
{
    private Waves Waves;
    private EnemiesSpawner EnemiesSpawner;
    private EnemiesFactory EnemiesFactory;
    private float Timer;
    private int WaveIndex;

    public SpawnByWaves(Waves waves, EnemiesSpawner enemiesSpawner, EnemiesFactory enemiesFactory)
    {
        Waves = waves;
        EnemiesSpawner = enemiesSpawner;
        EnemiesFactory = enemiesFactory;
    }

    public void WavesSpawn()
    {
        WaveSettings[] ArrayWave = Waves.waveSettings;

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            if (WaveIndex >= Waves.waveSettings.Length) return;

            if (ArrayWave[WaveIndex].AmountEnemies > 0)
            {
                Timer = Random.Range(0.1f, 0.7f);
                EnemiesSpawner.Spawn();
                ArrayWave[WaveIndex].AmountEnemies--;
            }

            if (ArrayWave[WaveIndex].AmountEnemies == 0)
            {
                if (EnemiesFactory.enemies.Count == 0)
                {
                    WaveIndex++;
                    Debug.Log(WaveIndex);
                }
            }
        }
    }
}
