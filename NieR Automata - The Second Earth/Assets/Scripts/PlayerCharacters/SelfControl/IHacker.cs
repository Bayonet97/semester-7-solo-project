using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHacker
{
    float HackingRange { get; }

    bool InRange { get; }
    int HackingSpeed { get; }
    void ControlContamination(IContaminated contaminated);
    Contaminated HackingTarget { get; }
}
