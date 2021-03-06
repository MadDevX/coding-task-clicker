﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMorePassiveUpgrades : MonoBehaviour
{
    private MorePassiveUpgrade _upgrade;

    private GameSettings _gameSettings;
    private MorePassiveUpgrade _nextUpgrade;

    public int UpgradeCount
    {
        get
        {
            if (_upgrade == null)
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
        _nextUpgrade = new MorePassiveUpgrade(null, _gameSettings);
    }

    public float ApplyUpgradeBonus(float baseIncome)
    {
        if (_upgrade == null)
        {
            return baseIncome;
        }
        else
        {
            return _upgrade.GetBonus(baseIncome);
        }
    }

    public bool CanBuyUpgrade(PlayerMoney playerMoney)
    {
        var cost = GetNextUpgradeCost();
        return UpgradeCount < _gameSettings.morePassiveUpgradeMaxCount && playerMoney.Money >= cost;
    }

    public void BuyUpgrade(PlayerMoney playerMoney)
    {
        if (CanBuyUpgrade(playerMoney))
        {
            playerMoney.Money -= GetNextUpgradeCost();
            _upgrade = new MorePassiveUpgrade(_upgrade, _gameSettings);
        }
    }

    private float GetNextUpgradeCost()
    {
        return _nextUpgrade.GetUpgradeCost(_upgrade);
    }
}
