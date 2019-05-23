using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreButton : MyButton
{
    public HighscoreLoader loader;

    protected override void OnClick()
    {
        SaveSystem.ResetHighscore();
        loader.UpdateHighscoreText();
    }
}
