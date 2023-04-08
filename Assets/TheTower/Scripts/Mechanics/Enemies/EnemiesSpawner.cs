using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesSpawner
{
    private Waves Waves;
    private Tower Tower;
    private EnemiesFactory EnemiesFactory;
    private float radius = 14;

    public EnemiesSpawner(Tower tower, EnemiesFactory enemiesFactory, Waves waves)
    {
        Tower = tower;
        EnemiesFactory = enemiesFactory;
        Waves = waves;
    }

    public void Spawn()
    {
        var randomVector2 = Random.insideUnitCircle.normalized;
        var randomVector3 = new Vector3(randomVector2.x, 0.0f, randomVector2.y);
        var spawnPoint = randomVector3 * Random.Range(radius - 2, radius + 2) + Tower.transform.position;

        var enemy = EnemiesFactory.Spawn(spawnPoint, Quaternion.identity);
        enemy.SetTarget(Tower);
    }
}
