using UnityEngine;

public class ChangeSkillsOnClick : MonoBehaviour
{
    public TheValueOfSkills _theValueOfSkills;
    public float ValueOfIncreaseSpeed = 0.05f;

    public void IncreaseAttackSpeed()
    {
        _theValueOfSkills.SpeedAttack += ValueOfIncreaseSpeed;
    }
    private void Update()
    {
        Debug.Log( _theValueOfSkills.SpeedAttack); 
    }
}
