using System;
using UnityEngine;

[Serializable]
public class Card
{
    public Sprite image;

    public string name;

    public DamageType damageType;
    public int damage = 10;
}
