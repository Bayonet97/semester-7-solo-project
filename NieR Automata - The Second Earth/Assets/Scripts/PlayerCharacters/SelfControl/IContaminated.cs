using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContaminated
{
    int SelfControl { get; set; }
    int MaxSelfControl { get; set; }
    int DrainRate { get; }
    bool Draining { get; set; }
    void DrainSelfControl(int amount);
    void RestoreSelfControl(int amount);
}
