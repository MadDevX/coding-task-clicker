using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PercentageOutcome
{
    public static void ApplyOutcome(PlayerMoney playerMoney, float bonus)
    {
        playerMoney.Money += playerMoney.Money * bonus;
    }
}
