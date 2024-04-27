using Assets.Scripts;

public class Enemy : Entity
{
    public EnemyType type;

    void Awake()
    {
        Respawn();
    }
}
