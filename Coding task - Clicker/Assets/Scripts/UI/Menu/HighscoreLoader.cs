using System;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreLoader : MonoBehaviour
{
    public string noScoreText;
    private Text _textBox;

    private void Awake()
    {
        _textBox = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateHighscoreText();
    }

    public void UpdateHighscoreText()
    {
        var score = SaveSystem.LoadHighscore();
        if (score.HasValue)
        {
            _textBox.text = HighscoreFormatter.Format(score.Value);
        }
        else
        {
            _textBox.text = noScoreText;
        }
    }
}
