using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameEventController : MonoBehaviour
{
    private GameLoop _gameLoop;
    private PrefabManager _prefabManager;
    private GameSettings _gameSettings;
    private IInitializableDialog<GameEvent> _eventDialog;

    private float _timeSinceCheck;

    [Inject]
    public void Construct(GameLoop gameLoop, PrefabManager prefabManager, GameSettings gameSettings, IDialogProvider dialogProvider)
    {
        _gameLoop = gameLoop;
        _prefabManager = prefabManager;
        _gameSettings = gameSettings;
        _eventDialog = dialogProvider.GetEventDialog(); 
    }

    private void Awake()
    {
        _gameLoop.OnUpdate += ProcessRandomEvents;
    }

    private void OnDestroy()
    {
        _gameLoop.OnUpdate -= ProcessRandomEvents;
    }

    private void ProcessRandomEvents(float deltaTime)
    {
        _timeSinceCheck += deltaTime;
        if(_timeSinceCheck >= _gameSettings.randomEventInterval)
        {
            _timeSinceCheck = _timeSinceCheck - _gameSettings.randomEventInterval;

            var list = _prefabManager.gameEvents;

            FisherYatesShuffle(list); // eliminates prejudice towards selecting first elements from the list

            foreach(var gameEvent in list)
            {
                var rand = Random.Range(0.0f, 1.0f);
                if(rand < gameEvent.probability)
                {
                    FireEvent(gameEvent);
                    break;
                }
            }
        }
    }

    private void FireEvent(GameEvent gameEvent)
    {
        _eventDialog.InitDialog(gameEvent);
        _eventDialog.ShowDialog();
    }

    private void FisherYatesShuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
