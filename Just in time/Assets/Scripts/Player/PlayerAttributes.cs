using System.Collections;
using UnityEngine;

///<sumary>Class that holds information and logic behind player's attributes</sumary>
public class PlayerAttributes : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private float speed = 250f;
    [SerializeField] private float jumpForce = 10f;
    
    public bool IsUnderSpeedBoost { get; private set; } = false;
    public float Speed => speed;
    public float JumpForce => jumpForce;
    public float HealthPoints => healthPoints;

    private float _originalSpeed;

    private void Start() => _originalSpeed = speed;

    public void SpeedUp(float deltaSpeed, float speedUpTime, float timeToWaitForBoost = 5f) => StartCoroutine(IncreaseSpeed(deltaSpeed, speedUpTime, timeToWaitForBoost));

    private IEnumerator IncreaseSpeed(float deltaSpeed, float speedUpTime, float timeToWaitForBoost)
    {
        IsUnderSpeedBoost = true;
        
        float secondsToWait = timeToWaitForBoost / 10f;
        float speedToIncreaseForIteration = deltaSpeed / 10f;

        while (speed != _originalSpeed + deltaSpeed)
        {
            speed += speedToIncreaseForIteration;
            yield return new WaitForSeconds(secondsToWait);
        }

        yield return new WaitForSeconds(speedUpTime);

        IsUnderSpeedBoost = false;
        speed = _originalSpeed;
    }

    public void Hurt(float damage)
    {
        healthPoints -= Mathf.Max(0, damage);
        if (healthPoints < 1) 
            Destroy(gameObject);
    }

    public void Heal(float regenerationPoints)
    {
        healthPoints += Mathf.Max(0, regenerationPoints);
        healthPoints = Mathf.Min(healthPoints, 100); //Change last value if health could be more then 100 points
    }
}
