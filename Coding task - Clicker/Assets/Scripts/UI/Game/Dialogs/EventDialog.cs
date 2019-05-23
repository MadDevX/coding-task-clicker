using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EventDialog : MonoBehaviour, IInitializableDialog<GameEvent>
{
    public Text eventTitleTextBox;
    public Text eventDescriptionTextBox;
    public GameObject optionsPanel;

    private DiContainer _container;
    private PrefabManager _prefabManager;
    private GameManager _gameManager;

    private List<GameObject> _optionButtons = new List<GameObject>();

    [Inject]
    public void Construct(DiContainer container, PrefabManager prefabManager, GameManager gameManager)
    {
        _container = container;
        _prefabManager = prefabManager;
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

        DestroyOptionButtons();
    }

    public void InitDialog(GameEvent gameEvent)
    {
        eventTitleTextBox.text = gameEvent.title;
        eventDescriptionTextBox.text = gameEvent.description;

        CreateOptionButtons(gameEvent);
    }

    private void CreateOptionButtons(GameEvent gameEvent)
    {
        foreach(var option in gameEvent.options)
        {
            var optionButton = _container.InstantiatePrefab(_prefabManager.optionButton, optionsPanel.transform);
            _optionButtons.Add(optionButton);
            optionButton.GetComponent<EventOptionButton>().InitButton(option);
        }
    }

    private void DestroyOptionButtons()
    {
        foreach(var button in _optionButtons)
        {
            Destroy(button);
        }
        _optionButtons.Clear();
    }
}
