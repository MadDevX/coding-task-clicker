using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    public DialogProvider dialogProvider;

    public override void InstallBindings()
    {
        Container.Bind<IDialogProvider>().FromInstance(dialogProvider).AsSingle();
    }
}
