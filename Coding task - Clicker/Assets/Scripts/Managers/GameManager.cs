using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public event Action OnGameStarted;
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnGameFinished;

    private IDialog _finishDialog;

    [Inject]
    public void Construct(IDialogProvider dialogProvider)
    {
        _finishDialog = dialogProvider.GetFinishDialog();
    }

    public bool IsGameRunning { get; set; }

    private void Awake()
    {
        OnGameFinished += _finishDialog.ShowDialog;
    }

    private void Start()
    {
        StartGame();
    }

    private void OnDestroy()
    {
        OnGameFinished -= _finishDialog.ShowDialog;
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
        IsGameRunning = true;
    }

    public void PauseGame()
    {
        OnGamePaused?.Invoke();
        IsGameRunning = false;
    }

    public void ResumeGame()
    {
        OnGameResumed?.Invoke();
        IsGameRunning = true;
    }

    public void FinishGame()
    {
        OnGameFinished?.Invoke();
        IsGameRunning = false;
    }
}
