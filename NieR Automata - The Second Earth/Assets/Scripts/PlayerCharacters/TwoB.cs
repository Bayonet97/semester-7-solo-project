using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwoB : PlayerCharacterBase
{
    public Contaminated Contaminated;
    private Vector2 randomSway;
    bool drainingPaused = false;
    int side; // left is 0, right is 1
    [SerializeField]
    private GameObject leftKillTarget;
    [SerializeField]
    private GameObject rightKillTarget;
    //private bool canMurder;

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

    new protected void FixedUpdate()
    {
        base.FixedUpdate();

        if (Contaminated.Draining && drainingPaused == false)
        {
            Contaminated.DrainSelfControl(Contaminated.DrainRate);
        }
    }

    protected override void InteractPerformed(InputAction.CallbackContext obj)
    {
        if (Contaminated.SelfControl > 0)
        {
            base.InteractPerformed(obj);

            if(ObjectInRange != null && ObjectInRange.name == "Button Right Door")
            {
                side = 1;
            }
            else if(ObjectInRange != null && ObjectInRange.name == "Button Left Door")
            {
                side = 0;
            }
        }
    }

    public IEnumerator MurderSomeone()
    {
        yield return new WaitForSeconds(2);
        if (side == 0)
        {
            leftKillTarget.GetComponent<InteractableObject>().GetKilled();
            transform.position = leftKillTarget.transform.position;
        } 
        else if(side == 1)
        {
            rightKillTarget.GetComponent<InteractableObject>().GetKilled();
            transform.position = rightKillTarget.transform.position;
        }
        Contaminated.OnSelfControlEmpty -= StartMurdering;
    }

    protected override void Move()
    {
        if (Contaminated.SelfControl > 0)
        {  
            // Goes from 0.0 to 1.0 depending on current SelfControl and takes 20% of the value. 
            float finalTwitchMultiplier = 0.3f * Contaminated.SelfControlCurve.Evaluate((float)Contaminated.SelfControl / 100);

            // Adds the twitch value % randomly to the initial movement input.
            Vector2 twitchMovementDirection = AddRandomMovement(oldMovementInput, finalTwitchMultiplier);

            twitchMovementDirection.Normalize();
            // Determines the movement direction and speed in the world space. 
            Vector3 worldDirection = new Vector3(twitchMovementDirection.x * speed, 0, twitchMovementDirection.y * speed);
            //Look at direction
            rigidbody.MoveRotation(Quaternion.LookRotation(worldDirection));
            // Move
            rigidbody.MovePosition(transform.position + worldDirection * Time.fixedDeltaTime);
        }
      
    }

    private Vector2 AddRandomMovement(Vector2 direction, float multiplier)
    {
        //TODO add variable that saves the last random result for both x and y. Base the new random value on the previous one if input direction is the same. 
        if(randomSway == null || randomSway == Vector2.zero)
        {
            randomSway = direction;
        }

        randomSway.Normalize();
        randomSway *= multiplier;
        randomSway = new Vector2(randomSway.x + UnityEngine.Random.Range(0 - multiplier, 0 + multiplier), randomSway.y + UnityEngine.Random.Range(0 - multiplier, 0 + multiplier));

        Vector2 randomDirection = new Vector2(direction.x + randomSway.x, direction.y + randomSway.y);
        return randomDirection;
    }
    public override void UpdateCharacterDialogueState(DialogueState state)
    {
        base.UpdateCharacterDialogueState(state);
        if (state != DialogueState.Disabled)
        {
            controls.TwobControls.Move.performed -= MovePerformed;
            if (Contaminated.Draining)
            {
                drainingPaused = true;
            }

        }
        else if (state == DialogueState.Disabled)
        {
            controls.TwobControls.Move.performed += MovePerformed;
            if (Contaminated.Draining)
            {
                drainingPaused = false;
            }
        }
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        ButtonInteractable.OnDoorOpen += CanMurder;
        controls.TwobControls.Enable();
    }

    private  void CanMurder()
    {
        //canMurder = true;
        Contaminated.OnSelfControlEmpty += StartMurdering;
    }

    private void StartMurdering()
    {
        StartCoroutine(MurderSomeone());
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        controls.TwobControls.Disable();
    }

}
