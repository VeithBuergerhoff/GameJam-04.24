using Assets.Scripts;
using UnityEngine;

public class Enemy : Entity
{
    public SpriteRenderer image;

    public EnemyType type;

    public Card drop;

    void Awake()
    {
        Respawn();
    }

    public void SwapToSlime() {
        image.sprite = Resources.Load<Sprite>("Enemy Images/Monster_Schleim");
        type = EnemyType.Slime;
        maxHealth = 100;
        health = 50;
        healthBar.UpdateHealth(health);
    }

    public void SwapToTentacle() {
        image.sprite = Resources.Load<Sprite>("Enemy Images/Monster_Tentakelmonster");
        type = EnemyType.Tentacle;
        maxHealth = 100;
        health = 5;
        healthBar.UpdateHealth(health);
    }

    public void SwapToChongusDragon() {
        image.sprite = Resources.Load<Sprite>("Enemy Images/Monster_Chongusdragon");        
        type = EnemyType.ChongusDragon;
        maxHealth = 100;
        health = 5;
        healthBar.UpdateHealth(health);
    }

    public void SwapToEldrichShadow() {
        image.sprite = Resources.Load<Sprite>("Enemy Images/Monster_Eldritchschatten");
        type = EnemyType.EldrichShadow;
        maxHealth = 100;
        health = 5;
        healthBar.UpdateHealth(health);
    }
}
