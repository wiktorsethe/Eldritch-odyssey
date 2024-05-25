using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}
public class BattleSystem : MonoBehaviour
{
    public BattleState battleState;
    public bool turnAction = false;
    public BattleUnit playerUnit; // Tymczasowo public, wywołuj jako parametr w SetupBattle()
    public BattleUnit enemyUnit; // Tymczasowo public, wywołuj jako parametr w SetupBattle()
    private BattleSystemHUD _battleSystemHUD;
    private BattleAction _playerActionUsed;
    
    private void Start()
    {
        _battleSystemHUD = FindObjectOfType(typeof(BattleSystemHUD)) as BattleSystemHUD;
        battleState = BattleState.START;
        SetupBattle();
    }
    
    private void SetupBattle()
    {
        // Do dokończenia
        _battleSystemHUD.AppendMessage("The fight between " + playerUnit.unitName + " and " + enemyUnit.unitName);
        battleState = BattleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {
        if (playerUnit.currentHealth <= 0)
        {
            battleState = BattleState.LOST;
            LostTurn();
            yield return null;
        }
        else
        {
            turnAction = false;
            Debug.Log("<color=yellow>----- Tura Gracza -----</color>");
            float elapsedTime = 0f;
            while (!turnAction && elapsedTime < 15f)
            {
                _battleSystemHUD.SetPlayerTurnTimer((int)elapsedTime);
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            if (turnAction)
            {
                Debug.Log("<color=green>Tura udana!</color>");
                
                if (_playerActionUsed.type == BattleAction.TypeOfAction.ATTACK)
                {
                    _battleSystemHUD.AppendMessage(playerUnit.unitName + " used " + _playerActionUsed.actionName +
                                                   " and takes: " + _playerActionUsed.attackAmount + " points of " +
                                                   enemyUnit.unitName + " health.");
                }
                else if (_playerActionUsed.type == BattleAction.TypeOfAction.SUPPORT)
                {
                    _battleSystemHUD.AppendMessage(playerUnit.unitName + " used " + _playerActionUsed.actionName +
                                                   " and receive: " + _playerActionUsed.healAmount + 
                                                   " points of health.");
                }
                else if (_playerActionUsed.type == BattleAction.TypeOfAction.DEFEND)
                {
                    _battleSystemHUD.AppendMessage(playerUnit.unitName + " used " + _playerActionUsed.actionName +
                                                   " and receive: " + _playerActionUsed.defensePower + 
                                                   " points of shield.");
                }
                
                battleState = BattleState.ENEMYTURN;
                EnemyTurn();
                yield break;
            }
        
            yield return null;
            Debug.LogWarning("<color=red>Tura zmarnowana!</color>");
            battleState = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }
    
    public void SetPlayerTurn(BattleAction action)
    {
        turnAction = true;
        _playerActionUsed = action;
    }
    
    private void EnemyTurn()
    {
        if (enemyUnit.currentHealth <= 0)
        {
            battleState = BattleState.WON;
            WinTurn();
        }
        else
        {
            Debug.Log("<color=yellow>----- Tura Przeciwnika -----</color>");
            // DO ZROBIENIA ENEMY AI
            playerUnit.currentHealth -= enemyUnit.actions[0].attackAmount;
            _battleSystemHUD.AppendMessage(enemyUnit.unitName + " used " + enemyUnit.actions[0].actionName +
                                           " and takes: " + enemyUnit.actions[0].attackAmount + " points of " +
                                           playerUnit.unitName + " health.");
            battleState = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }
    }

    private void LostTurn()
    {
        // Do dokończenia
        Debug.LogWarning("<color=red>----- Walka Przegrana! -----</color>");

    }

    private void WinTurn()
    {
        // Do dokończenia
        Debug.LogWarning("<color=green>----- Walka Wygrana! -----</color>");

    }
}

