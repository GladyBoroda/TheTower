using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 10;

    private Vector3 TargetPosition;
    private Enemy Target;
    private TheValueOfSkills _theValueOfSkills;


    public void Construct(Enemy Target, TheValueOfSkills theValueOfSkills)
    {
        this.Target = Target;
        TargetPosition = Target.transform.position;
        _theValueOfSkills = theValueOfSkills;
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
                Target.OnHit(_theValueOfSkills.Damage);
            }
        }
    }
}
