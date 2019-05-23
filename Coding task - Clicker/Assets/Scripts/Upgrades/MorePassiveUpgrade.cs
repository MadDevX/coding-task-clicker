using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePassiveUpgrade : DecoratedUpgrade<MorePassiveUpgrade>, IUpgrade<MorePassiveUpgrade>
{
    public MorePassiveUpgrade(MorePassiveUpgrade decoratedUpgrade, GameSettings gameSettings) : base(decoratedUpgrade, gameSettings)
    {
    }

    public float GetBonus(float baseIncome)
    {
        if (_decoratedUpgrade == null)
        {
            return _gameSettings.morePassiveUpgradeFlatIncome + baseIncome;
        }
        else
        {
            return _gameSettings.morePassiveUpgradeFlatIncome + _decoratedUpgrade.GetBonus(baseIncome);
        }
    }

    public float GetUpgradeCost(MorePassiveUpgrade previousUpgrade)
    {
        if (previousUpgrade == null)
        {
            return _gameSettings.morePassiveUpgradeBaseCost;
        }
        else
        {
            return _gameSettings.morePassiveUpgradeSubsequentCost * previousUpgrade.UpgradeCount + _gameSettings.morePassiveUpgradeBaseCost;
        }
    }
}
