using System;
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
    public string unitName;
    //public int stamina;
    private BattleSystemHUD _battleSystemHUD;
    public List<BattleAction> actions = new List<BattleAction>();
    
    private void Start()
    {
        _battleSystemHUD = GameObject.FindObjectOfType(typeof(BattleSystemHUD)) as BattleSystemHUD;
    }

    private void OnMouseEnter()
    {
        _battleSystemHUD.ShowUnitView(this);
    }

    private void OnMouseExit()
    {
        _battleSystemHUD.HideUnitView();
    }

    private void OnMouseDown()
    {
        if(_battleSystemHUD.GetCombatPanelActivity()) 
            _battleSystemHUD.HideCombatPanel();
        _battleSystemHUD.ShowCombatPanel(unitType, this);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}