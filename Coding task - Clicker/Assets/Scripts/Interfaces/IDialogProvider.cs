using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogProvider
{
    IInitializableDialog<GameEvent> GetEventDialog();
    IInitializableDialog<Outcome> GetOutcomeDialog();
    IDialog GetExitDialog();
    IDialog GetBonusDialog();
    IDialog GetFinishDialog();
}
