using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoB : PlayerCharacterBase, IContaminated
{

    public delegate void SelfControlChanged(int newValue);
    public static event SelfControlChanged OnSelfControlChanged;

    [SerializeField]
    private int _selfControl;
    public int SelfControl
    {
        get => _selfControl;
        set
        {
            _selfControl = value;
            OnSelfControlChanged(value);
        }
    }
    private float selfControlDecimal;

    [SerializeField]
    private int _drainRate;

    public int DrainRate { get => _drainRate; set => _drainRate = value; }

    public bool Draining { get; set; } = true;
    protected override void Awake()
    {
        base.Awake();

        // When the left stick is moved (mapped to MoveCharacter1), it will call performed.
        // performed will give a context (mv) which has a readable value of the stick's direction.
        // move is then set to the stick's direction.
        controls.TwobControls.Move.performed += MovePerformed;
        // When the stick is idle, canceled will be called setting move to Vector2.zero.
        controls.TwobControls.Move.canceled += MoveCanceled;

        controls.TwobControls.Interact.performed += InteractPerformed;

        selfControlDecimal = _selfControl;
    }

    new private void Update()
    {
        base.Update();

        if (Draining)
        {
            DrainSelfControl(_drainRate);
        }
    }

    protected override void OnEnable()
    {
        controls.TwobControls.Enable();
    }

    protected override void OnDisable()
    {
        controls.TwobControls.Disable();
    }

    public void DrainSelfControl(int amount)
    {
        selfControlDecimal -= amount * Time.deltaTime;
        SelfControl = Mathf.RoundToInt(selfControlDecimal);
    }
}
