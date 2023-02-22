using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform Target;
    private float Speed = 0.5f;
    private float EnemyHealth = 1;
    EnemiesFactory enemiesFactory;

    public void Construct(EnemiesFactory enemiesFactory)
    {
        this.enemiesFactory = enemiesFactory;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void OnHit(float damage)
    {
        EnemyHealth -= damage;

        if (EnemyHealth >= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        enemiesFactory.enemies.Remove(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
        transform.LookAt(Target.position);
    }
}
