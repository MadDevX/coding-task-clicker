using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ExitDialog : MonoBehaviour, IDialog
{
    protected GameManager _gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public virtual void ShowDialog()
    {
        _gameManager.PauseGame();
        transform.parent.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public virtual void HideDialog()
    {
        _gameManager.ResumeGame();
        transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
