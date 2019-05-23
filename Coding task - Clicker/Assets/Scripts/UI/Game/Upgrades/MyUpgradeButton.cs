using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class MyUpgradeButton : MyButton
{
    private GameLoop _gameLoop;

    [Inject]
    public void Construct(GameLoop gameLoop)
    {
        _gameLoop = gameLoop;
    }

    protected override void Start()
    {
        base.Start();
        _gameLoop.OnUpdate += OnUpdate;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _gameLoop.OnUpdate -= OnUpdate;
    }

    protected abstract void OnUpdate(float deltaTime);
}
