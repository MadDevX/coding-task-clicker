using UnityEngine;
using Zenject;

public class PlayerBonuses : MonoBehaviour
{
    private PercentageBonus _morePassiveBonus;
    private PercentageBonus _fasterPassiveBonus;
    private PercentageBonus _activeBonus;

    private GameLoop _gameLoop;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(GameLoop gameLoop, GameSettings gameSettings)
    {
        _gameLoop = gameLoop;
        _gameSettings = gameSettings;
    }

    private void Start()
    {
        _gameLoop.OnUpdate += OnUpdate;
    }

    private void OnDestroy()
    {
        _gameLoop.OnUpdate -= OnUpdate;
    }

    private void OnUpdate(float deltaTime)
    {
        if (_activeBonus != null &&_activeBonus.CheckIfEnded(deltaTime)) _activeBonus = null;
        if (_morePassiveBonus != null && _morePassiveBonus.CheckIfEnded(deltaTime)) _morePassiveBonus = null;
        if (_fasterPassiveBonus != null && _fasterPassiveBonus.CheckIfEnded(deltaTime)) _fasterPassiveBonus = null;
    }

    public float ApplyBonus(BonusType type, float value)
    {
        switch(type)
        {
            case (BonusType.Active):
                return _activeBonus != null ? _activeBonus.ApplyBonus(value) : value;
            case (BonusType.MorePassive):
                return _morePassiveBonus != null ? _morePassiveBonus.ApplyBonus(value) : value;
            case (BonusType.FasterPassive):
                return _fasterPassiveBonus != null ? _fasterPassiveBonus.ApplyBonus(value) : value;
            default:
                return value;
        }
    }

    public bool CanCreateBonus(BonusType type)
    {
        switch (type)
        {
            case (BonusType.Active):
                return _activeBonus == null;
            case (BonusType.MorePassive):
                return _morePassiveBonus == null;
            case (BonusType.FasterPassive):
                return _fasterPassiveBonus == null;
            default:
                return false;
        }
    }

    public bool CreateBonus(BonusType type)
    {
        switch(type)
        {
            case (BonusType.Active):
                if (CanCreateBonus(type))
                {
                    CreateMoreActiveBonus();
                    return true;
                }
                break;
            case (BonusType.MorePassive):
                if (CanCreateBonus(type))
                {
                    CreateMorePassiveBonus();
                    return true;
                }
                break;
            case (BonusType.FasterPassive):
                if (CanCreateBonus(type))
                {
                    CreateFasterPassiveBonus();
                    return true;
                }
                break;
        }
        return false;
    }

    private void CreateMoreActiveBonus()
    {
        _activeBonus = new PercentageBonus(_gameSettings.activeBonusDuration, _gameSettings.activeBonusPercentage);
    }

    private void CreateMorePassiveBonus()
    {
        _morePassiveBonus = new PercentageBonus(_gameSettings.morePassiveBonusDuration, _gameSettings.morePassiveBonusPercentage);
    }

    private void CreateFasterPassiveBonus()
    {
        _fasterPassiveBonus = new PercentageBonus(_gameSettings.fasterPassiveBonusDuration, _gameSettings.fasterPassiveBonusPercentage);
    }

}
