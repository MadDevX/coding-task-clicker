using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade<T>
{
    int UpgradeCount { get; }
    float GetBonus(float baseValue);
    float GetUpgradeCost(T previousUpgrade);
}
