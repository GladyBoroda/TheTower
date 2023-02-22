using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //public Enemy Target;
    public GameObject SpawnBulletPosition;
    public float SpeedBullet;
    private float Timer;
    private EnemiesDetecter EnemiesDetecter;
    private ContentService contentService;

    public void Construct(ContentService contentService, EnemiesDetecter EnemiesDetecter)
    {
        this.contentService = contentService;
        this.EnemiesDetecter = EnemiesDetecter;
    }

    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else
        {
            if (EnemiesDetecter.CheckEnemyInRadius(out var target))
            {
                Timer = 1;
                var bullet = Instantiate(contentService.BulletPrefab, SpawnBulletPosition.transform.position, Quaternion.identity);
                bullet.Construct(target);
            }
        }
    }


}
