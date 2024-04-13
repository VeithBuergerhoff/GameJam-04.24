using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public HealthBar healthBar;
    public Player player;

    void Awake()
    {
        player.health = player.maxHealth;
        healthBar.SetMaxHealth(player.maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(10);
            healthBar.UpdateHealth(player.health);
        }
    }
}
