using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Random Game Event")]
public class GameEvent : ScriptableObject
{
    public string title;
    public string description;
    public float probability;
    public List<Option> options;

    [System.Serializable]
    public class Option
    {
        public string name;
        public List<Outcome> outcomes;
    }
}
