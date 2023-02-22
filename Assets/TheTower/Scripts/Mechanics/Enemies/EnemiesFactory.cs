using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactory
{
    private ContentService contentService;
    public List<Enemy> enemies;

    public EnemiesFactory (ContentService contentService)
    {
        this.contentService = contentService;
        enemies = new List<Enemy>();
    }
    
    public Enemy Spawn(Vector3 position, Quaternion quaternion)
    {
        var enemy = Object.Instantiate(contentService.EnemyPrefab, position, quaternion);
        enemy.Construct(this);
        enemies.Add(enemy);

        return enemy;
    }

}
