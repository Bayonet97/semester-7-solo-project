using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerCharacterBase : MonoBehaviour
{
    // Reference to the mapping object of the controls
    protected PlayerControls controls;

    [SerializeField]
    protected Animator characterAnimator;

    protected Vector2 movement;

    [SerializeField]
    protected float speed;

    protected virtual void Awake()
    {
        controls = new PlayerControls();
    }

    protected void Update()
    {
        if (movement != Vector2.zero)
        {
            Move();
        }
    }

    private void Move() 
    {
        // When moving, the stick's direction is taken and translated to x and z axis.
        Vector3 direction = new Vector3(movement.x * speed, 0, movement.y * speed);
        // The character then takes that direction and moves in world space.
        transform.Translate(direction * Time.deltaTime, Space.World);
        //transform.LookAt(direction);
        characterAnimator.SetFloat("Vertical", Mathf.Abs(movement.y) + Mathf.Abs(movement.x));
    }

    protected void MovePerformed(InputAction.CallbackContext stickDirection)
    {
        //stickDirection left - right is x value. up down is y value.
        movement = stickDirection.ReadValue<Vector2>();        
    }

    protected void MoveCanceled(InputAction.CallbackContext obj)
    {
        movement = Vector2.zero;
        Debug.Log("Stopped moving");
        characterAnimator.SetFloat("Vertical", 0f);
    }

    protected void InteractPerformed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    protected abstract void OnEnable();

    protected abstract void OnDisable();
}
