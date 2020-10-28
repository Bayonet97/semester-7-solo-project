using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : InteractableObject
{

    private Transform closedRotation;
    private float openRotation = 90f;

    bool isDoorMoving = false;

    public override void Interact()
    {
        if (!isDoorMoving)
        {
            StartCoroutine(Open(closedRotation, openRotation, 1f));
        }
    }
    IEnumerator Open(Transform fromPosition, float toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isDoorMoving)
        {
            yield break; ///exit if this is still running
        }
        isDoorMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Transform startPos = fromPosition;
        transform.rotation = Quaternion.Euler(0, toPosition, 0);
        while (counter < duration)
        {
            counter += Time.deltaTime;

            yield return null;
        }

        isDoorMoving = false;
        StartCoroutine(Close(openRotation, closedRotation, 1f));
    }

    IEnumerator Close(float fromPosition, Transform toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isDoorMoving)
        {
            yield break; ///exit if this is still running
        }

        GetComponent<Renderer>().material.SetColor("_Color", Color.gray);

        isDoorMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        //Vector3 startPos = fromPosition;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            // door.transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isDoorMoving = false;
    }
}
