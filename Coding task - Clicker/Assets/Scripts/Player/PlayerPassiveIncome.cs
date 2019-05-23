using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerPassiveIncome : MonoBehaviour
{
    private PlayerMoney _playerMoney;
    private GameLoop _gameLoop;
    private GameSettings _gameSettings;
    private PlayerMorePassiveUpgrades _morePassiveUpgrades;
    private PlayerFasterPassiveUpgrades _fasterPassiveUpgrades;
    private PlayerBonuses _playerBonuses;

    private float _currentTime;

    [Inject]
    public void Construct(GameLoop gameLoop, GameSettings gameSettings, PlayerMoney playerMoney, 
                          PlayerMorePassiveUpgrades morePassiveUpgrades,
                          PlayerFasterPassiveUpgrades fasterPassiveUpgrades,
                          PlayerBonuses playerBonuses)
    {
        _gameLoop = gameLoop;
        _gameSettings = gameSettings;
        _playerMoney = playerMoney;
        _morePassiveUpgrades = morePassiveUpgrades;
        _fasterPassiveUpgrades = fasterPassiveUpgrades;
        _playerBonuses = playerBonuses;
    }

    private void Awake()
    {
        _gameLoop.OnUpdate += OnUpdate;
    }

    private void OnDestroy()
    {
        _gameLoop.OnUpdate -= OnUpdate;
    }

    private void OnUpdate(float deltaTime)
    {
        _currentTime += deltaTime;
        if(_currentTime >= GetPassiveIncomeDelay())
        {
            _playerMoney.Money += GrantBonus();
            _currentTime = _currentTime - GetPassiveIncomeDelay();
        }
    }

    private float GetPassiveIncomeDelay()
    {
        return _playerBonuses.ApplyBonus(BonusType.FasterPassive, _fasterPassiveUpgrades.ApplyUpgradeBonus(_gameSettings.passiveIncomeBaseDelay));
    }

    private float GrantBonus()
    {
        return _playerBonuses.ApplyBonus(BonusType.MorePassive, _morePassiveUpgrades.ApplyUpgradeBonus(0.0f));
    }
}
