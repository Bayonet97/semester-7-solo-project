using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContaminated
{
    int SelfControl { get; set; }

    int DrainRate { get; }
    void DrainSelfControl();
}
