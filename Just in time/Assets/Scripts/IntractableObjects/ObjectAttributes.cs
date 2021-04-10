using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttributes : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private float healthPoints = 100;
    [SerializeField] [Range(0, 100)] private float damage = 0;
    [SerializeField] private bool _isImmortal = false;
    
    public float HealthPoints => healthPoints;
    public float Damage => damage;

    public bool IsImmortal => _isImmortal;

    public void Hurt(float damage)
    {
        if (!_isImmortal) 
            healthPoints -= Mathf.Max(0, damage);
        if(healthPoints < 1)
            Destroy(gameObject);
    }

    public void Heal(float healingPoints)
    {
        healthPoints += Mathf.Max(0, healingPoints);
        healthPoints = Mathf.Min(healthPoints, 100); //Change last value if health could be more then 100 points
    }
}