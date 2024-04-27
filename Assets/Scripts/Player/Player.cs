using Assets.Scripts;
using UnityEngine;

public class Player : Entity
{
    public CardDisplay cardDisplay;

    void Awake()
    {
        Respawn();
    }
}
