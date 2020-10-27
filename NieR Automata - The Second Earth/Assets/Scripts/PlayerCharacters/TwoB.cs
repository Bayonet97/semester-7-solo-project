using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

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

    protected override void InteractPerformed(InputAction.CallbackContext obj)
    {
        if (Contaminated.SelfControl > 0)
        {
            base.InteractPerformed(obj);
        }
    }

    protected override void Move()
    {
        // Goes from 0.0 to 1.0 depending on current SelfControl and takes 20% of the value. 
        float finalTwitchMultiplier = 0.6f * Contaminated.SelfControlCurve.Evaluate((float)Contaminated.SelfControl / 100);

        // Adds the twitch value % randomly to the initial movement input.
        Vector2 twitchMovementDirection = oldMovementInput * UnityEngine.Random.Range(1 - finalTwitchMultiplier, 1 + finalTwitchMultiplier);

        // Determines the movement direction and speed in the world space. 
        Vector3 worldDirection = new Vector3(twitchMovementDirection.x * speed, 0, twitchMovementDirection.y * speed);
        //Look at direction
        transform.rotation = Quaternion.LookRotation(worldDirection);
        // Move
        transform.Translate(worldDirection * Time.deltaTime, Space.World);
    }

    public override void UpdateCharacterDialogueState(DialogueState state)
    {
        base.UpdateCharacterDialogueState(state);
        if (state != DialogueState.Disabled)
        {
            controls.TwobControls.Move.performed -= MovePerformed;
        }
        else if (state == DialogueState.Disabled)
        {
            controls.TwobControls.Move.performed += MovePerformed;
        }
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        controls.TwobControls.Enable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        controls.TwobControls.Disable();
    }

}
