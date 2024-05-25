using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleSystemHUD : MonoBehaviour
{
    [SerializeField] private GameObject unitViewPrefab;
    [SerializeField] private GameObject combatPanelPrefab;
    [SerializeField] private GameObject combatButtonPrefab;
    [SerializeField] private Text combatLogContent;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private TMP_Text playerTurnTimer;
    private GameObject _combatPanel;
    private GameObject _unitView;
    private BattleUnit _battleUnit;
    private BattleSystem _battleSystem;
    private bool _isCombatPanelActive;

    private void Start()
    {
        _battleSystem = FindObjectOfType(typeof(BattleSystem)) as BattleSystem;
        _isCombatPanelActive = false;
    }
    
    public void ShowUnitView(BattleUnit unit)
    {
        if(!_unitView)
        {
            if (Camera.main != null)
                _unitView = Instantiate(unitViewPrefab, 
                    (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition),
                    Quaternion.identity, 
                    transform);
        }
        else
        {
            _unitView.SetActive(true);
            _unitView.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        _unitView.transform.Find("UnitNameText").GetComponent<TMP_Text>().text =
            unit.unitName;
        _unitView.transform.Find("UnitHPText").GetComponent<TMP_Text>().text =
            unit.currentHealth + "/" + unit.maxHealth;
    }
    
    public void HideUnitView()
    {
        _unitView.SetActive(false);
    }
    
    public void ShowCombatPanel(Type unitType, BattleUnit battleUnit)
    {
        if(_unitView) _unitView.SetActive(false);
        
        if(!_combatPanel)
        {
            if (Camera.main != null)
                _combatPanel = Instantiate(combatPanelPrefab,
                    (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                    Quaternion.identity, 
                    transform);
        }
        else
        {
            _combatPanel.SetActive(true);
            _combatPanel.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        _isCombatPanelActive = true;
        _battleUnit = battleUnit;
        
        if (unitType == Type.PLAYER)
        {
            foreach (BattleAction action in battleUnit.actions)
            {
                if (action.type != BattleAction.TypeOfAction.ATTACK)
                {
                    AddButton(ActionUsage, action);
                }
            }
        }
        else if (unitType == Type.ENEMY)
        {
            foreach (BattleAction action in battleUnit.actions)
            {
                if (action.type == BattleAction.TypeOfAction.ATTACK)
                {
                    AddButton(ActionUsage, action);
                }
            }
        }
    }
    
    public void HideCombatPanel()
    {
        if (_combatPanel.activeSelf)
        {
            for (int i=0; i<_combatPanel.transform.childCount; i++)
            {
                GameObject child = _combatPanel.transform.GetChild(i).gameObject;
                Destroy(child);
            }

            _isCombatPanelActive = false;
            _combatPanel.SetActive(false);
            _battleUnit.transform.GetComponent<Collider2D>().enabled = true;
        }
    }
    
    public bool GetCombatPanelActivity()
    {
        return _isCombatPanelActive;
    }
    
    private void AddButton(Action<BattleAction> action, BattleAction battleAction)
    {
        GameObject combatButton = Instantiate(combatButtonPrefab, _combatPanel.transform);
        combatButton.transform.GetComponentInChildren<TMP_Text>().text = battleAction.actionName;
        combatButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            action?.Invoke(battleAction);
        });
    }
    
    // DO PRZEROBIENIA, TRZEBA TO PRZENIEŚĆ DO BATTLESYSTEM.CS
    private void ActionUsage(BattleAction action)
    {
        if(action.type == BattleAction.TypeOfAction.ATTACK) 
            _battleUnit.currentHealth -= action.attackAmount;
        else if (action.type == BattleAction.TypeOfAction.SUPPORT)
            _battleUnit.currentHealth += action.healAmount;
        else if (action.type == BattleAction.TypeOfAction.DEFEND)
            // Do dokończenia, prawdopodobnie od ataku przeciwnika bedzie odejmowana połowa mocy obrony
            _battleUnit.currentHealth += action.defensePower;
        _battleSystem.SetPlayerTurn(action);
        HideCombatPanel();
    }
    
    public void AppendMessage(string message)
    {
        StartCoroutine(AppendAndScroll(message));
    }
    
    private IEnumerator AppendAndScroll(string message)
    {
        combatLogContent.text += message + "\n";

        yield return null;
        scrollbar.value = 1;
    }
    
    public void SetPlayerTurnTimer(int sec)
    {
        playerTurnTimer.text = "Waiting " + (15 - sec) + " sec. for player's turn...";
    }
}
