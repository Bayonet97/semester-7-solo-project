using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBSuspectInteractable : SuspectInteractable
{

    [SerializeField]
    private Contaminated contaminated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(contaminated.SelfControl > 0 && contaminated.Draining)
        {
            contaminated.DrainSelfControl(5);
        }
    }

    public void Empty()
    {

    }

    public void OnEnable()
    {
        Contaminated.OnSelfControlEmpty += Empty;
    }
}
