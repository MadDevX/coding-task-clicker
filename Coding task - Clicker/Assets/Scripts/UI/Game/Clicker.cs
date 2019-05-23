using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Clicker : MonoBehaviour
{
    private Button _button;
    private PlayerActiveIncome _activeIncome;

    [Inject]
    public void Construct(PlayerActiveIncome activeIncome)
    {
        _activeIncome = activeIncome;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _activeIncome.Click();
    }
}
