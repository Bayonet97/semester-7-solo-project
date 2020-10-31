using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractableObject : InteractableObject
{
/*    public delegate void RockMovedAside();
    public static event RockMovedAside OnRockMovedAside;*/

    public override void Interact()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.59f, -0.64f, 39.47f), 0.5f );
//
/*        if(gameObject.transform.position == new Vector3(0.27f, -0.5f, 36f))
        {
            OnRockMovedAside();
        }*/
    }

/*     IEnumerator Open(Transform fromPosition, float toPosition, float duration)
    {
        open = true;
        //Make sure there is only one instance of this function running
        if (isDoorMoving)
        {
            yield break; ///exit if this is still running
        }
        isDoorMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Transform startPos = fromPosition;
        door.transform.rotation = Quaternion.Euler(0, toPosition, 0);
        while (counter < duration)
        {
            counter += Time.deltaTime;
            
            yield return null;
        }
        OnDoorOpen();
        isDoorMoving = false;
        //StartCoroutine(Close(openRotation, closedRotation, 1f));
    }*/

}
