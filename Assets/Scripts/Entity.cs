﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Entity : MonoBehaviour
    {
        public HealthBar healthBar;

        public int maxHealth = 100;
        public int health;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            healthBar.UpdateHealth(health);
        }

        public void Respawn()
        {
            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }
}
