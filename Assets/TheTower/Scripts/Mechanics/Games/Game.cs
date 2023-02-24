using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public ContentService ContentService;
    public Tower Tower;
    public Waves waves;

    private EnemiesSpawner EnemiesSpawner;
    private EnemiesFactory EnemiesFactory;
    private SpawnByWaves SpawnByWaves;
    

    private void Awake()
    {
        EnemiesFactory = new EnemiesFactory(ContentService);
        EnemiesSpawner = new EnemiesSpawner(Tower, EnemiesFactory,waves);
        SpawnByWaves = new SpawnByWaves(waves, EnemiesSpawner, EnemiesFactory);
        Tower.Construct(ContentService, new EnemiesDetecter(EnemiesFactory, Tower));
    }

    private void Update()
    {
        SpawnByWaves.WavesSpawn();
    }
}
