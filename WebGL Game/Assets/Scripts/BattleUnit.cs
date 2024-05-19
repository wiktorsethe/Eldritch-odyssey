using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    PLAYER,
    ENEMY
}
public class BattleUnit : MonoBehaviour
{
    [SerializeField] private Type unitType;
    public int damage;
    public int currentHealth;
    public int maxHealth;
    //public int stamina;

    private void OnMouseEnter()
    {
        BattleSystem.Instance.ShowUnitView();
    }

    private void OnMouseExit()
    {
        BattleSystem.Instance.HideUnitView();
    }

    private void OnMouseDown()
    {
        BattleSystem.Instance.ShowCombatPanel(unitType, this);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}