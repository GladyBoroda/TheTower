using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetecter
{
    private EnemiesFactory enemiesFactory;
    private Tower Tower;
    private float Radius = 12;

    public EnemiesDetecter(EnemiesFactory enemiesFactory, Tower tower)
    {
        this.enemiesFactory = enemiesFactory;
        Tower = tower;
    }

    public bool CheckEnemyInRadius(out Enemy enemy)
    {
        enemy = null;
        if (enemiesFactory.enemies.Count == 0)
        {
            return false;
        }
        
        float minDistans = float.MaxValue;

        foreach (var item in enemiesFactory.enemies)
        {
            float curDistanceToTower = (item.transform.position - Tower.transform.position).sqrMagnitude;

            if (curDistanceToTower < Radius * Radius)
            {
                if (curDistanceToTower < minDistans)
                {
                    minDistans = curDistanceToTower;
                    enemy = item;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
