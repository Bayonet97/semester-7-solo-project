using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoB : PlayerCharacterBase, IContaminated
{

    public delegate void SelfControlChanged(int newValue);
    public static event SelfControlChanged OnSelfControlChanged;

    [SerializeField]
    private int _maxSelfControl;
    public int MaxSelfControl { get => _maxSelfControl; set => _maxSelfControl = value; }

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

    [SerializeField]
    private bool _draining;
    public bool Draining { get => _draining; set => _draining = value; }

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

    new protected void Update()
    {
        base.Update();

        if (Draining)
        {
            DrainSelfControl(_drainRate);
        }
    }

    protected override void Move()
    {
        // When moving, the stick's direction is taken and translated to x and z axis.
        Vector3 direction = new Vector3(oldMovementInput.x * speed, 0, oldMovementInput.y * speed);
        transform.rotation = Quaternion.LookRotation(direction);

        if (SelfControl != MaxSelfControl && SelfControl > 0)
        {
            float controlLoss = MaxSelfControl - SelfControl;

            oldMovementInput = UnityEngine.Random.onUnitSphere * controlLoss;
/*            float randomDirectionVariance = UnityEngine.Random.Range(1 - (controlLoss / 100), 1 + (controlLoss / 100));

            movementInput.x *= randomDirectionVariance;*/
        }
        else if(SelfControl <= 0)
        {
            return;
        }

        // The character then takes that direction and moves in world space.
        transform.Translate(direction * Time.deltaTime, Space.World);
    }

    public override void ChangePausedState(bool paused)
    {
        if (paused)
        {
            controls.TwobControls.Disable();
        }
        else if (!paused)
        {
            controls.TwobControls.Enable();
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
        if(SelfControl > 0)
        {
            selfControlDecimal -= amount * Time.deltaTime;
            SelfControl = Mathf.RoundToInt(selfControlDecimal);
        }
    }

    public void RestoreSelfControl(int amount)
    {
        if(SelfControl < MaxSelfControl)
        {
            selfControlDecimal += amount * Time.deltaTime;
            SelfControl = Mathf.RoundToInt(selfControlDecimal);
        }
    }
}
