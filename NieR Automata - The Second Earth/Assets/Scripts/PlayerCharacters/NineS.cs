using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NineS : PlayerCharacterBase
{
    protected override void Awake()
    {
        base.Awake();

        // When the left stick is moved (mapped to MoveCharacter1), it will call performed.
        // performed will give a context (mv) which has a readable value of the stick's direction.
        // move is then set to the stick's direction.
        controls.NinesControls.Move.performed += MovePerformed;
        // When the stick is idle, canceled will be called setting move to Vector2.zero.
        controls.NinesControls.Move.canceled += MoveCanceled;

        controls.NinesControls.Interact.performed += InteractPerformed;
    }

    protected override void OnDisable()
    {
        controls.NinesControls.Enable();
    }

    protected override void OnEnable()
    {
        controls.NinesControls.Disable();
    }
}
