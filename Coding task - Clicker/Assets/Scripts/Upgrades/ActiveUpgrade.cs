using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUpgrade : DecoratedUpgrade<ActiveUpgrade>, IUpgrade<ActiveUpgrade>
{
    public ActiveUpgrade(ActiveUpgrade decoratedUpgrade, GameSettings gameSettings) : base(decoratedUpgrade, gameSettings)
    {
    }

    public float GetBonus(float baseIncome)
    {
        if (_decoratedUpgrade != null)
        {
            return _gameSettings.activeUpgradeIncomeMult * _decoratedUpgrade.GetBonus(baseIncome);
        }
        else
        {
            return _gameSettings.activeUpgradeIncomeMult * baseIncome;
        }
    }

    public float GetUpgradeCost(ActiveUpgrade previousUpgrade)
    {
        var mult = _gameSettings.activeUpgradeCostMult * _gameSettings.activeUpgradeIncomeMult;
        if (previousUpgrade == null)
        {
            return mult * _gameSettings.baseClickValue;
        }
        else
        {
            return mult * previousUpgrade.GetBonus(_gameSettings.baseClickValue);
        }
    }
}
