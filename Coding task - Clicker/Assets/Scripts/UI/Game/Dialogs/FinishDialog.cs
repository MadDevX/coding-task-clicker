using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FinishDialog : ExitDialog
{
    public string format;
    public Text _textbox;

    private ScoreCounter _score;

    [Inject]
    public void Construct(ScoreCounter score)
    {
        _score = score;
    }

    public override void ShowDialog()
    {
        _textbox.text = string.Format(format, HighscoreFormatter.Format(_score.PlayTime));
        transform.parent.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}
