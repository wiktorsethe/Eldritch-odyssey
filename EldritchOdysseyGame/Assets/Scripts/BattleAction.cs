using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle Action", menuName = "Battle Action")]
public class BattleAction : ScriptableObject
{
    public enum TypeOfAction
    {
        ATTACK,
        SUPPORT,
        DEFEND
    };
    public TypeOfAction type;

    public string actionName;
    public int healAmount;
    public int attackAmount;
    public int defensePower;
}
