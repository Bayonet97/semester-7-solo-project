using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractionFlow
{
    public List<string> Dialogue;
    [SerializeField] private bool _repeatable;

    public InteractionFlow()
    {
        Dialogue = new List<string>();
    }

    public bool GetRepeatable()
    {
        return _repeatable;
    }
}