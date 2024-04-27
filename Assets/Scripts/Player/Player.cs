using Assets.Scripts;

public class Player : Entity
{
    public CardDisplay cardDisplay;

    void Awake()
    {
        Respawn();
    }
}
