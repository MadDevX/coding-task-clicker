using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatOutcome
{
    public static void ApplyOutcome(PlayerMoney playerMoney, float bonus)
    {
        playerMoney.Money += bonus;
    }
}
