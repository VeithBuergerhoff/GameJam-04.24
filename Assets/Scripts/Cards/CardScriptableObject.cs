using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardScriptableObject", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public string displayName;
    public Sprite sprite;
}
