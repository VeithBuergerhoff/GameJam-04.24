using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;

    public Enemy enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            enemy.TakeDamage(10);
        }
    }
}
