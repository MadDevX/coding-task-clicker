using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MorePassiveUpgradeButton : MyUpgradeButton
{
    private PlayerMoney _playerMoney;
    private PlayerMorePassiveUpgrades _playerUpgrades;

    [Inject]
    public void Construct(PlayerMoney playerMoney, PlayerMorePassiveUpgrades playerUpgrades)
    {
        _playerMoney = playerMoney;
        _playerUpgrades = playerUpgrades;
    }

    protected override void OnClick()
    {
        _playerUpgrades.BuyUpgrade(_playerMoney);
    }

    protected override void OnUpdate(float deltaTime)
    {
        if (_playerUpgrades.CanBuyUpgrade(_playerMoney))
        {
            if (_button.interactable == false) _button.interactable = true;
        }
        else
        {
            if (_button.interactable == true) _button.interactable = false;
        }
    }
}
