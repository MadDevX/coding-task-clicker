using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighscoreFormatter
{
    public static string Format(float score)
    {
        TimeSpan time = TimeSpan.FromSeconds(score);
        return time.ToString("hh':'mm':'ss");
    }
}
