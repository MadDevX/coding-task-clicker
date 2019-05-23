using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPassiveUpgrade : DecoratedUpgrade<FasterPassiveUpgrade>, IUpgrade<FasterPassiveUpgrade>
{
    public FasterPassiveUpgrade(FasterPassiveUpgrade decoratedUpgrade, GameSettings gameSettings) : base(decoratedUpgrade, gameSettings)
    {
    }

    public float GetBonus(float baseDelay)
    {
        if (_decoratedUpgrade != null)
        {
            return CalculateBonus(_decoratedUpgrade.GetBonus(baseDelay));
        }
        else
        {
            return CalculateBonus(baseDelay);
        }
    }

    public float GetUpgradeCost(FasterPassiveUpgrade previousUpgrade)
    {
        if (previousUpgrade == null)
        {
            return _gameSettings.fasterPassiveUpgradeBaseCost;
        }
        else
        {
            return _gameSettings.fasterPassiveUpgradeSubsequentCost;
        }
    }

    private float CalculateBonus(float baseDelay)
    {
        var timeBonus = _gameSettings.fasterPassiveUpgradeFirstStep;
        while (timeBonus >= baseDelay) timeBonus *= _gameSettings.fasterPassiveUpgradeStepMult;
        return baseDelay - timeBonus;
    }
}
