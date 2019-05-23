using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInitializableDialog<T> : IDialog
{
    void InitDialog(T data);
}
