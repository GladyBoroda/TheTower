using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;
    private Vector3 TargetPosition;
    private Enemy Target;

    public void Construct(Enemy Target)
    {
        this.Target = Target;
        TargetPosition = Target.transform.position;
    }

    void Update()
    {
        if (Target)
        {
            TargetPosition = Target.transform.position;
        }

        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * Speed);

        if ((transform.position - TargetPosition).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
            if (Target)
            {
                Target.OnHit(1);
            }
            
        }

    }

}
