using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }
}
