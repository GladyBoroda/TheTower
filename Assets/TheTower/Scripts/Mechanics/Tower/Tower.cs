using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject SpawnBulletPosition;
    public Canvas CanvasDie;
    public TheValueOfSkills TheValueOfSkills;
    public float SpeedBullet;
    public int Health = 5;

    private float Timer;
    private EnemiesDetecter EnemiesDetecter;
    private ContentService contentService;

    public void Construct(ContentService contentService, EnemiesDetecter EnemiesDetecter)
    {
        this.contentService = contentService;
        this.EnemiesDetecter = EnemiesDetecter;
    }

    public void Die()
    {
        Debug.Log("DIEEEEE!");
        CanvasDie.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }

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
                bullet.Construct(target, TheValueOfSkills);
            }
        }
    }
}
