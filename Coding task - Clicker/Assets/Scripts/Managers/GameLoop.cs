using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    /// <summary>
    /// Invoked on every update if the game is not paused with Time.deltaTime as an argument.
    /// </summary>
    public Action<float> OnUpdate;

    private GameManager _gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    void Update()
    {
        if (_gameManager.IsGameRunning)
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }
    }
}
