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
    [SerializeField] private GameObject unitViewPrefab;
    [SerializeField] private GameObject combatPanelPrefab;
    [SerializeField] private GameObject combatButtonPrefab;
    private GameObject _combatPanel;
    private GameObject _unitView;
    private BattleUnit _battleUnit;
    public BattleState battleState;
    private bool _turnAction = false;
    public static BattleSystem Instance { get; private set; }
    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
            battleState = BattleState.START;
            SetupBattle();
    }
    private void SetupBattle()
    {
            // Do dokończenia
            battleState = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {
        _turnAction = false;
        Debug.LogWarning("<color=yellow>-----Tura Gracza-----</color>");
        float elapsedTime = 0f;
        while (!_turnAction && elapsedTime < 15f)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        if (_turnAction)
        {
            Debug.Log("<color=green>Tura udana!</color>");
            battleState = BattleState.ENEMYTURN;
            EnemyTurn();
            yield break;
        }
        
        yield return null;
        Debug.LogWarning("<color=red>Tura zmarnowana!</color");
        battleState = BattleState.ENEMYTURN;
        EnemyTurn();
    }
    private void EnemyTurn()
    {
            Debug.LogWarning("<color=yellow>-----Tura Przeciwnika-----</color>");
            battleState = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
    }
    public void ShowUnitView()
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
        
        _battleUnit = battleUnit;
        
        if (unitType == Type.PLAYER)
        {
            // Do rozbudowy
            AddButton("Heal", Heal);
        }
        else if (unitType == Type.ENEMY)
        {
            // Do rozbudowy
            AddButton("Attack 1", Attack);
            AddButton("Attack 2", Attack);
        }
    }
    private void HideCombatPanel()
    {
        if (_combatPanel.activeSelf)
        {
            for (int i=0; i<_combatPanel.transform.childCount; i++)
            {
                    GameObject child = _combatPanel.transform.GetChild(i).gameObject;
                    Destroy(child);
            }
            _combatPanel.SetActive(false);
            _battleUnit.transform.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void AddButton(string desc, Action action)
    {
        GameObject combatButton = Instantiate(combatButtonPrefab, _combatPanel.transform);
        combatButton.transform.GetComponentInChildren<TMP_Text>().text = desc;
        combatButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            action?.Invoke();
        });
    }
    private void Heal()
    {
        HideCombatPanel();
        if(battleState != BattleState.PLAYERTURN) return;
        
        _turnAction = true;
        Debug.Log("(Healed)");
    }
    private void Attack()
    {
        HideCombatPanel();
        if(battleState != BattleState.PLAYERTURN) return;
        
        _turnAction = true;
        Debug.Log("(Attacked)");
    }
}

