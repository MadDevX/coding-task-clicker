using System;
using UnityEngine;

[System.Serializable]
public class Outcome
{
    public string description;
    [Range(0.0f, 1.0f)]
    public float probability;
    public OutcomeType bonusType;
    public float bonus;

    public void ApplyOutcome(PlayerMoney playerMoney)
    {
        switch(bonusType)
        {
            case OutcomeType.Flat:
                FlatOutcome.ApplyOutcome(playerMoney, bonus);
                break;
            case OutcomeType.Percentage:
                PercentageOutcome.ApplyOutcome(playerMoney, bonus);
                break;
        }
    }
}
