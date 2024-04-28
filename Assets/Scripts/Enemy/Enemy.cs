using System;
using Assets.Scripts;
using UnityEngine;

public class Enemy : Entity
{
    public SpriteRenderer image;

    public EnemyStats[] enemies;
    public int enemyIndex = -1;

    public EnemyStats CurrentEnemy => enemies[enemyIndex];

    [Serializable]
    public class EnemyStats
    {
        public Sprite sprite;
        public EnemyType type;
        public int maxHealth;
        public int damage;
        public Card[] drops;
    }

    void Awake()
    {
        LoadNextEnemy();
    }

    public bool LoadNextEnemy()
    {
        if (++enemyIndex >= enemies.Length)
        {
            return false;
        }
        var enemy = CurrentEnemy;
        image.sprite = enemy.sprite;
        maxHealth = enemy.maxHealth;
        Respawn();
        return true;
    }
}
