using Assets.Scripts;

public class Enemy : Entity
{
    public EnemyType type;

    public Card drop;

    void Awake()
    {
        Respawn();
    }
}
