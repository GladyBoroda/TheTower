using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 0.5f;

    private Tower Target;
    private float EnemyHealth = 1;
    private EnemiesFactory enemiesFactory;

    private float Timer;

    public void Construct(EnemiesFactory enemiesFactory)
    {
        this.enemiesFactory = enemiesFactory;
    }

    public void SetTarget(Tower target)
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

    public void MakeDamage()
    {
        Debug.Log("Damage");
        Target.Health --;
    }

    public void Die()
    {
        enemiesFactory.enemies.Remove(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        if ((transform.position - Target.transform.position).sqrMagnitude > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
        }

        if ((transform.position - Target.transform.position).sqrMagnitude <= 1)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = 1;
                MakeDamage();
            }

        }

        transform.LookAt(Target.transform.position);
    }
}
