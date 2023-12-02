using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    public float coolDownTime = 1f;

    public float currentCooldown;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (currentCooldown <= 0)
            {
                _playerHealth.TakeDamage(1);
                currentCooldown = coolDownTime;
            }
        }
    }
}