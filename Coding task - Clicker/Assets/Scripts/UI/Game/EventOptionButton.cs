using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EventOptionButton : MonoBehaviour
{
    public Text buttonText;
    public Button button;

    private GameEvent.Option _option;

    private GameManager _gameManager;
    private IInitializableDialog<GameEvent> _eventDialog;
    private IInitializableDialog<Outcome> _outcomeDialog;
    private PlayerMoney _playerMoney;

    [Inject]
    public void Construct(GameManager gameManager, PlayerMoney playerMoney, IDialogProvider dialogProvider)
    {
        _gameManager = gameManager;
        _eventDialog = dialogProvider.GetEventDialog();
        _outcomeDialog = dialogProvider.GetOutcomeDialog();
        _playerMoney = playerMoney;
    }

    private void Start()
    {
        button.onClick.AddListener(ProcessOutcome);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ProcessOutcome);
    }

    public void InitButton(GameEvent.Option option)
    {
        _option = option;
        buttonText.text = _option.name;
    }

    private void ProcessOutcome()
    {
        var outcome = GetOutcome();
        outcome.ApplyOutcome(_playerMoney);

        _eventDialog.HideDialog();

        _outcomeDialog.InitDialog(outcome);
        _outcomeDialog.ShowDialog();
    }

    private Outcome GetOutcome()
    {
        float result = Random.Range(0.0f, GetAggregatedProbability());
        float currentProbability = 0.0f;

        for (int i = 0; i < _option.outcomes.Count; i++)
        {
            currentProbability += _option.outcomes[i].probability;
            if (currentProbability >= result)
            {
                return _option.outcomes[i];
            }
        }
        return _option.outcomes[_option.outcomes.Count - 1];
    }

    private float GetAggregatedProbability()
    {
        float sum = 0.0f;
        foreach(var outcome in _option.outcomes)
        {
            sum += outcome.probability;
        }
        return sum;
    }
}
