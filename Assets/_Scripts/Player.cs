using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;

    [SerializeField]
    public class PlayerStats
    {
        public int currentHealth;
    }
        public int maxHealth = 100;

    public PlayerStats playerStats = new PlayerStats();


    void Start()
    {
        playerStats.currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        playerStats.currentHealth -= damage;

        healthBar.SetHealth(playerStats.currentHealth);

        if(playerStats.currentHealth <= 0)
        {
            GameManager.KillPlayer(this);
            healthBar.SetHealth(playerStats.currentHealth);
        }
    }
}
