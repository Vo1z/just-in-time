using System;
using System.Collections;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 250f;
    [SerializeField] private float jumpForce = 10f;

    public float Speed => speed;
    public float JumpForce => jumpForce;
    public float Health => health;


    private float _originalSpeed;

    private void Start()
    {
        _originalSpeed = speed;
    }

    private void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
            //todo debug
            Debug.Log("Game Over");
        }
    }

    private IEnumerator IncreaseSpeed(float deltaSpeed, float speedUpTime, float timeToWaitForBoost)
    {
        float secondsToWait = timeToWaitForBoost / 10f;
        float speedToIncreaseForIteration = deltaSpeed / 10f;

        while (speed != _originalSpeed + deltaSpeed)
        {
            speed += speedToIncreaseForIteration;
            yield return new WaitForSeconds(secondsToWait);
        }

        yield return new WaitForSeconds(speedUpTime);

        speed = _originalSpeed;
    }
    
    public void SpeedUp(float deltaSpeed, float speedUpTime, float timeToWaitForBoost = 5f)
    {
        StartCoroutine(IncreaseSpeed(deltaSpeed, speedUpTime, timeToWaitForBoost));
        
        //todo debug
        Debug.Log($"{deltaSpeed} speed were added for {speedUpTime} to {gameObject.name}");
    }

    public void Hurt(float damage)
    {
        health -= damage;
        
        //todo debug
        Debug.Log($"{damage} damage was dealt to {gameObject.name}");
    }

    public void RegenerateHealth(float regenerationPoints)
    {
        health += regenerationPoints;
        
        //todo debug
        Debug.Log($"{regenerationPoints} hp was regenerated to {gameObject.name}");
    }
}
