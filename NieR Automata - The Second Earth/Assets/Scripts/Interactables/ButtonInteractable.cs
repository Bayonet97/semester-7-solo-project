using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : InteractableObject
{
    [SerializeField]
    private GameObject door;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    bool isDoorMoving = false;

    public void Start()
    {
        closedPosition = door.transform.position;
        openPosition= new Vector3(door.transform.position.x - 4, door.transform.position.y, door.transform.position.z);
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
            door.transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
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
            door.transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }

        isDoorMoving = false;
    }
}
