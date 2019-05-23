using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerActiveIncome : MonoBehaviour
{
    private GameSettings _gameSettings;
    private PlayerMoney _playerMoney;
    private PlayerActiveUpgrades _playerUpgrades;
    private PlayerBonuses _playerBonuses;

    [Inject]
    public void Construct(GameSettings gameSettings, PlayerMoney playerMoney, PlayerActiveUpgrades playerActiveUpgrades, PlayerBonuses playerBonuses)
    {
        _gameSettings = gameSettings;
        _playerMoney = playerMoney;
        _playerUpgrades = playerActiveUpgrades;
        _playerBonuses = playerBonuses;

    }

    public void Click()
    {
        _playerMoney.Money += GetClickMoney();
    }

    private float GetClickMoney()
    {
        return _playerBonuses.ApplyBonus(BonusType.Active, _playerUpgrades.ApplyUpgradeBonus(_gameSettings.baseClickValue));
    }
}
