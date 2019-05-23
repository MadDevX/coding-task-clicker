using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour
{
    protected Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}
