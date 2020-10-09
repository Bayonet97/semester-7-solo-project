using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHacker
{
    float HackingRange { get; }
    int HackingSpeed { get; }
    void ControlContamination(IContaminated contaminated);
    IContaminated HackingTarget { get; }
}
