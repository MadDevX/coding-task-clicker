using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratedUpgrade<UpgradeType> where UpgradeType: IUpgrade<UpgradeType>
{
    protected UpgradeType _decoratedUpgrade;
    protected GameSettings _gameSettings;

    public DecoratedUpgrade(UpgradeType decoratedUpgrade, GameSettings gameSettings)
    {
        _decoratedUpgrade = decoratedUpgrade;
        _gameSettings = gameSettings;
    }

    public int UpgradeCount
    {
        get
        {
            if (_decoratedUpgrade == null)
            {
                return 1;
            }
            else
            {
                return _decoratedUpgrade.UpgradeCount + 1;
            }
        }
    }
}
