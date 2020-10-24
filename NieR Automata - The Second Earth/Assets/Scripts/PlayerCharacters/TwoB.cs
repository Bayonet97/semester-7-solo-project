using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoB : PlayerCharacterBase
{
    public Contaminated Contaminated;

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
    }

    new protected void Update()
    {
        base.Update();

        if (Contaminated.Draining)
        {
            Contaminated.DrainSelfControl(Contaminated.DrainRate);
        }
    }

    protected override void Move()
    {
        // When moving, the stick's direction is taken and translated to x and z axis.
        Vector3 direction = new Vector3(oldMovementInput.x * speed, 0, oldMovementInput.y * speed);
        transform.rotation = Quaternion.LookRotation(direction);

        if (Contaminated.SelfControl != Contaminated.MaxSelfControl && Contaminated.SelfControl > 0)
        {
           /* float controlLoss = MaxSelfControl - SelfControl;

            oldMovementInput = UnityEngine.Random.onUnitSphere * controlLoss;*/
/*            float randomDirectionVariance = UnityEngine.Random.Range(1 - (controlLoss / 100), 1 + (controlLoss / 100));

            movementInput.x *= randomDirectionVariance;*/
        }
        else if(Contaminated.SelfControl <= 0)
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
            oldMovementInput = Vector2.zero;
            Move();
            StopMovementAnimation();
            controls.TwobControls.Move.performed -= MovePerformed;
        }
        else if (!paused)
        {
            controls.TwobControls.Move.performed += MovePerformed;
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

}
