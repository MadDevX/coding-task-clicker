using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerActiveUpgrades : MonoBehaviour
{
    private ActiveUpgrade _upgrade;

    private GameSettings _gameSettings;
    private ActiveUpgrade _nextUpgrade;

    public int UpgradeCount
    {
        get
        {
            if(_upgrade == null)
            {
                return 0;
            }
            else
            {
                return _upgrade.UpgradeCount;
            }
        }
    }

    [Inject]
    public void Construct(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
        _nextUpgrade = new ActiveUpgrade(null, _gameSettings);
    }

    public float ApplyUpgradeBonus(float baseIncome)
    {
        if (_upgrade != null)
        {
            return _upgrade.GetBonus(baseIncome);
        }
        else
        {
            return baseIncome;
        }
    }

    public bool CanBuyUpgrade(PlayerMoney playerMoney)
    {
        var cost = GetNextUpgradeCost();
        return UpgradeCount < _gameSettings.activeUpgradeMaxCount && playerMoney.Money >= cost;
    }

    public void BuyUpgrade(PlayerMoney playerMoney)
    {
        if (CanBuyUpgrade(playerMoney))
        {
            playerMoney.Money -= GetNextUpgradeCost();
            _upgrade = new ActiveUpgrade(_upgrade, _gameSettings);
        }
    }

    private float GetNextUpgradeCost()
    {
        return _nextUpgrade.GetUpgradeCost(_upgrade);
    }

}
