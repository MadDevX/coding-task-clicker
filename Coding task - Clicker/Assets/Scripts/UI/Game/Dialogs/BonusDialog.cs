using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusDialog : MonoBehaviour, IDialog
{
    private GameManager _gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void ShowDialog()
    {
        _gameManager.PauseGame();
        transform.parent.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void HideDialog()
    {
        _gameManager.ResumeGame();
        transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
