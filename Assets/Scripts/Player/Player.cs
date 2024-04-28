using System.Collections.Generic;
using Assets.Scripts;

public class Player : Entity
{
    public CardDisplay cardDisplay;
    public List<Card> essences;

    void Awake()
    {
        Respawn();
    }
}
