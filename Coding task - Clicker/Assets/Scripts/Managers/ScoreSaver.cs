using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreSaver : MonoBehaviour
{
    private GameManager _gameManager;
    private ScoreCounter _score;

    [Inject]
    public void Construct(GameManager gameManager, ScoreCounter score)
    {
        _gameManager = gameManager;
        _score = score;
    }

    private void Awake()
    {
        _gameManager.OnGameFinished += SaveHighscore;
    }

    private void OnDestroy()
    {
        _gameManager.OnGameFinished -= SaveHighscore;
    }

    private void SaveHighscore()
    {
        var prevTime = SaveSystem.LoadHighscore();
        if(prevTime.HasValue == false || prevTime.Value > _score.PlayTime)
        {
            SaveSystem.SaveHighscore(_score.PlayTime);
        }
    }
}
