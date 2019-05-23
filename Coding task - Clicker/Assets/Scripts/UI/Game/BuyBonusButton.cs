using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuyBonusButton : MyUpgradeButton
{
    public BonusType bonusType;
    private PlayerBonuses _playerBonuses;

    [Inject]
    public void Construct(PlayerBonuses playerBonuses)
    {
        _playerBonuses = playerBonuses;
        
    }

    protected override void OnClick()
    {
        if(_playerBonuses.CreateBonus(bonusType))
        {
            _button.interactable = false;
        }
    }

    protected override void OnUpdate(float deltaTime)
    {
        if (_playerBonuses.CanCreateBonus(bonusType))
        {
            if (_button.interactable == false) _button.interactable = true;
        }
        else
        {
            if (_button.interactable == true) _button.interactable = false;
        }
    }
}
