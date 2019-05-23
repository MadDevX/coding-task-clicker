using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    public float PlayTime { get; private set; }

    private GameManager _gameManager;
    private GameLoop _gameLoop;


    [Inject]
    public void Construct(GameManager gameManager, GameLoop gameLoop)
    {
        _gameManager = gameManager;
        _gameLoop = gameLoop;
    }

    private void Awake()
    {
        _gameLoop.OnUpdate += OnUpdate;
        _gameManager.OnGameStarted += ResetTime;
    }

    private void OnDestroy()
    {
        _gameLoop.OnUpdate -= OnUpdate;
        _gameManager.OnGameStarted -= ResetTime;
    }

    private void ResetTime()
    {
        PlayTime = 0.0f;
    }

    private void OnUpdate(float deltaTime)
    {
        PlayTime += deltaTime;
    }
}
