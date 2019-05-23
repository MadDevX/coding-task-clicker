using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OutcomeDialog : MonoBehaviour, IInitializableDialog<Outcome>
{
    public Text outcomeMessageTextBox;

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

    public void InitDialog(Outcome outcome)
    {
        outcomeMessageTextBox.text = outcome.description;
    }
}
