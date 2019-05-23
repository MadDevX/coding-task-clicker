using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float targetMoney;
    public float baseClickValue;
    public float randomEventInterval;

    public float activeUpgradeIncomeMult;
    public float activeUpgradeCostMult;
    public int activeUpgradeMaxCount;

    public float morePassiveUpgradeFlatIncome;
    public float morePassiveUpgradeBaseCost;
    public float morePassiveUpgradeSubsequentCost;
    public int morePassiveUpgradeMaxCount;

    public float passiveIncomeBaseDelay;
    public float fasterPassiveUpgradeFirstStep;
    public float fasterPassiveUpgradeStepMult;
    public float fasterPassiveUpgradeBaseCost;
    public float fasterPassiveUpgradeSubsequentCost;
    public int fasterPassiveUpgradeMaxCount;

    public float activeBonusDuration;
    public float activeBonusPercentage;

    public float morePassiveBonusDuration;
    public float morePassiveBonusPercentage;

    public float fasterPassiveBonusDuration;
    public float fasterPassiveBonusPercentage;
}
