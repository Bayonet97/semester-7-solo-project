using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfControlBar : MonoBehaviour
{
    [SerializeField]
    private Slider selfControlBar;

    public Contaminated Infected;

    private void Awake()
    {
        //TwoB.OnSelfControlChanged += UpdateSelfControlBar;
        Contaminated.OnSelfControlChanged += UpdateSelfControlBar;
        Contaminated.OnSelfControlEmpty += SelfControlEmpty;
    }

    private void SelfControlEmpty()
    {
       //
    }

    private void UpdateSelfControlBar(int selfControl)
    {
        if(selfControlBar.value > selfControl)
        {
            // Change color of bar

           // selfControlBar..normalColor = Color.green;
        }
        selfControlBar.value = selfControl;
    }
}
