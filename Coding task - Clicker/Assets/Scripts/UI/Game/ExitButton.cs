using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExitButton : MyButton
{
    private IDialog _exitDialog;

    [Inject]
    public void Construct(IDialogProvider dialogProvider)
    {
        _exitDialog = dialogProvider.GetExitDialog();
    }

    protected override void OnClick()
    {
        _exitDialog.ShowDialog();
    }
}
