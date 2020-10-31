using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInteractable : InteractableObject
{
    private Vector3 closedPosition;
    private Vector3 openPosition;

    bool isDoorMoving = false;

    public void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
        StartCoroutine(Open(closedPosition, openPosition, 1.0f));
    }


    IEnumerator Open(Vector3 fromPosition, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isDoorMoving)
        {
            yield break; ///exit if this is still running
        }
        isDoorMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }

        isDoorMoving = false;
        StartCoroutine(Close(openPosition, closedPosition, 1f));
    }

    IEnumerator Close(Vector3 fromPosition, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isDoorMoving)
        {
            yield break; ///exit if this is still running
        }
        isDoorMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }

        isDoorMoving = false;
    }

    public void LockGate()
    {
        Destroy(GetComponent<GateInteractable>());
    }

    public void OnEnable()
    {
        // Subscribe to door open event.
        ButtonInteractable.OnDoorOpen += LockGate;
    }

    public void OnDisable()
    {
        // Subscribe to door open event.
        ButtonInteractable.OnDoorOpen -= LockGate;
    }
}
