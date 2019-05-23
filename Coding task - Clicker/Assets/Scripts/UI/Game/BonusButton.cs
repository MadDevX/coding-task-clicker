using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusButton : MyButton
{
    private IDialog _bonusDialog;

    [Inject]
    public void Construct(IDialogProvider dialogProvider)
    {
        _bonusDialog = dialogProvider.GetBonusDialog();
    }

    protected override void OnClick()
    {
        _bonusDialog.ShowDialog();
    }
}
