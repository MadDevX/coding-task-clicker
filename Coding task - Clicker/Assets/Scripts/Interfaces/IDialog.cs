using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialog
{
    /// <summary>
    /// Makes dialog visible.
    /// </summary>
    void ShowDialog();

    /// <summary>
    /// Makes dialog not visible.
    /// </summary>
    void HideDialog();
}
