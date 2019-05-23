using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogProvider : MonoBehaviour, IDialogProvider
{
    public EventDialog eventDialog;
    public OutcomeDialog outcomeDialog;
    public ExitDialog exitDialog;
    public BonusDialog bonusDialog;
    public FinishDialog finishDialog;

    public IDialog GetBonusDialog()
    {
        return bonusDialog;
    }

    public IInitializableDialog<GameEvent> GetEventDialog()
    {
        return eventDialog;
    }

    public IDialog GetExitDialog()
    {
        return exitDialog;
    }

    public IDialog GetFinishDialog()
    {
        return finishDialog;
    }

    public IInitializableDialog<Outcome> GetOutcomeDialog()
    {
        return outcomeDialog;
    }
}
