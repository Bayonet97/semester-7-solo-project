using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractableObject : InteractableObject
{
    public delegate void RockMovedAside();
    public static event RockMovedAside OnRockMovedAside;

    public override void Interact()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.27f, -0.5f, 36f), 5f * Time.deltaTime);

        if(gameObject.transform.position == new Vector3(0.27f, -0.5f, 36f))
        {
            OnRockMovedAside();
        }
    }
}
