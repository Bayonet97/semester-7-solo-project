using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfControlBar : MonoBehaviour
{
    [SerializeField]
    private Slider selfControlBar;

    [SerializeField] //Should be IContaminated interface but interface cant hold a Unity friendly event.
    private TwoB twoB;

    private void OnEnable()
    {
        TwoB.OnSelfControlChanged += UpdateSelfControlBar;
    }

    private void UpdateSelfControlBar(int selfControl)
    {
        selfControlBar.value = selfControl;
    }
}
