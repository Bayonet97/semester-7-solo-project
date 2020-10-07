using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHacker
{
    int HackingRange { get; }
    int HackingSpeed { get; }
    void ControlContamination();
}
