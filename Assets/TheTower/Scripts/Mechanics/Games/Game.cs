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
    

    private void Awake()
    {
        EnemiesFactory = new EnemiesFactory(ContentService);
        EnemiesSpawner = new EnemiesSpawner(Tower, EnemiesFactory,waves);
        Tower.Construct(ContentService, new EnemiesDetecter(EnemiesFactory, Tower));
    }

    private void Update()
    {
        EnemiesSpawner.WavesSpawn();
    }
}
