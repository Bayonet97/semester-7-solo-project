using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerCharacterBase : MonoBehaviour
{
    // Reference to the mapping object of the controls
    protected PlayerControls controls;

    [SerializeField]
    private GameObject characterBody;

    [SerializeField]
    protected Animator characterAnimator;

    protected Vector2 movementInput;

    [SerializeField]
    protected float speed;

    protected virtual void Awake()
    {
        controls = new PlayerControls();
    }

    protected void Update()
    {
        if (movementInput != Vector2.zero)
        {
            Move();
        }
    }

    private void Move() 
    {
        // When moving, the stick's direction is taken and translated to x and z axis.
        Vector3 direction = new Vector3(movementInput.x * speed, 0, movementInput.y * speed);
        // The character then takes that direction and moves in world space.
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    protected void MovePerformed(InputAction.CallbackContext stickDirection)
    {
        //stickDirection left - right is x value. up down is y value.
        Vector2 newMovementInput = stickDirection.ReadValue<Vector2>();
     
        if (newMovementInput == movementInput) 
            return;

        movementInput = newMovementInput;

        if (movementInput == Vector2.zero)
        {
            characterAnimator.SetFloat("MovementSpeed", 0f);
            return;
        }
        characterAnimator.SetFloat("MovementSpeed", movementInput.magnitude);
    }

    protected void MoveCanceled(InputAction.CallbackContext obj)
    {
        movementInput = Vector2.zero;
        characterAnimator.SetFloat("MovementSpeed", 0f);
    }

    protected void InteractPerformed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    protected abstract void OnEnable();

    protected abstract void OnDisable();
}
