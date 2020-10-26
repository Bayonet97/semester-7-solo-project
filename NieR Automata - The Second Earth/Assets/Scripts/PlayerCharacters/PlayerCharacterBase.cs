using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerCharacterBase : MonoBehaviour
{
    // Reference to the mapping object of the controls
    protected PlayerControls controls;

    [SerializeField] protected CharacterDialogue characterDialogue;
    [SerializeField] protected CharacterInteraction characterInteraction;

    protected Vector2 oldMovementInput;
    protected Vector2 newMovementInput;

    [SerializeField] protected Animator characterAnimator;

    [SerializeField] protected float speed;

    [SerializeField] private float interactionRange = 0.5f;

    protected virtual void Awake()
    {
        controls = new PlayerControls();
    }

    protected void Update()
    {
        if (oldMovementInput != Vector2.zero)
        {
            Move();
        }
    }

    protected virtual void Move() 
    {
        // When moving, the stick's direction is taken and translated to x and z axis.
        Vector3 direction = new Vector3(oldMovementInput.x * speed, 0, oldMovementInput.y * speed);
        // The character then takes that direction and moves in world space.
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    protected void MovePerformed(InputAction.CallbackContext stickDirection)
    {   
        //stickDirection left - right is x value. up down is y value.
        newMovementInput = stickDirection.ReadValue<Vector2>();

        if (newMovementInput == oldMovementInput) 
            return;

        oldMovementInput = newMovementInput;

        if (newMovementInput == Vector2.zero)
        {
            characterAnimator.SetFloat("MovementSpeed", 0f);
            return;
        }
        UpdateMovementAnimation(newMovementInput.magnitude);
    }

    protected void MoveCanceled(InputAction.CallbackContext obj)
    {
        oldMovementInput = Vector2.zero;
        StopMovementAnimation();
    }

    protected void InteractPerformed(InputAction.CallbackContext obj)
    {
        if (characterDialogue.GetDialogueState() != DialogueState.Disabled)
        {
            characterDialogue.NextState();
        }
        else
        {           
            RaycastHit objectInRange;
            if (Physics.Raycast(transform.position, transform.forward, out objectInRange, interactionRange))
            {
                
                if (objectInRange.collider.gameObject.GetComponent<InteractableObject>())
                    characterInteraction.InteractWithObject(objectInRange.collider.gameObject.GetComponent<InteractableObject>());
            }
        }

    }

    public void ShowDialogue(List<string> newDialogueText)
    {
        characterDialogue.OpenDialogue(newDialogueText);
    }
    public void UpdateMovementAnimation(float value)
    {
        characterAnimator.SetFloat("MovementSpeed", value);
    }

    public void StopMovementAnimation()
    {
        characterAnimator.SetFloat("MovementSpeed", 0f);
    }

    public abstract void ChangePausedState(DialogueState state);

    protected virtual void OnEnable() 
    {
        CharacterDialogue.OnDialogueStateChanged += ChangePausedState;
        CharacterInteraction.OnDialogueHasText += ShowDialogue;
    }

    protected virtual void OnDisable()
    {
        CharacterDialogue.OnDialogueStateChanged -= ChangePausedState;
        CharacterInteraction.OnDialogueHasText -= ShowDialogue;
    }
}
