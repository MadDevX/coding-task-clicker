using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageBonus
{
    private float _ttl;
    private float _bonus;

    public PercentageBonus(float duration, float bonus)
    {
        _ttl = duration;
        _bonus = bonus;
    }

    public float ApplyBonus(float baseValue)
    {
        return baseValue * (1.0f + _bonus);
    }

    public bool CheckIfEnded(float deltaTime)
    {
        _ttl -= deltaTime;
        if(_ttl <= 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
