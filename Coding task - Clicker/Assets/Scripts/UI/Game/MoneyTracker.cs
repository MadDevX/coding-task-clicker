using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MoneyTracker : MonoBehaviour
{
    public string format;
    private Text _textBox;
    private PlayerMoney _player;

    [Inject]
    public void Construct(PlayerMoney player)
    {
        _player = player;
    }

    private void Awake()
    {
        _textBox = GetComponent<Text>();

        _player.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnDestroy()
    {
        _player.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(float amount)
    {
        _textBox.text = string.Format(format, amount);
    }
}
