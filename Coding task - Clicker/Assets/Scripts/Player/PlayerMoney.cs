using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoney : MonoBehaviour
{
    public event Action<float> OnMoneyChanged;

    private GameManager _gameManager;
    private GameSettings _gameSettings;

    private float _currentMoney;
    public float Money
    {
        get
        {
            return _currentMoney;
        }

        set
        {
            _currentMoney = value;
            OnMoneyChanged?.Invoke(value);
        }
    }

    [Inject]
    public void Construct(GameManager gameManager, GameSettings gameSettings)
    {
        _gameManager = gameManager;
        _gameSettings = gameSettings;
    }

    private void Awake()
    {
        _gameManager.OnGameStarted += ResetMoney;
        OnMoneyChanged += CheckWinCondition;
    }

    private void OnDestroy()
    {
        _gameManager.OnGameStarted -= ResetMoney;
        OnMoneyChanged -= CheckWinCondition;
    }

    private void ResetMoney()
    {
        Money = 0.0f;
    }

    private void CheckWinCondition(float amount)
    {
        if (amount >= _gameSettings.targetMoney)
        {
            _gameManager.FinishGame();
        }
    }
}
