using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable

{
    [SerializeField] private float _maxHealth = 3f;
    private int mijnInt;
    private string mijnString;
    private float _currentHealth;
    private HealthBar _healthBar;

    private void Start()
    {
        _currentHealth = _maxHealth;

        _healthBar = GetComponentInChildren<HealthBar>();
    }

    public void Damage(float damageAmount)
    {
        //damage the enemy
        _currentHealth -= damageAmount;

        //update health bar
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        if (_currentHealth < 0) 
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
