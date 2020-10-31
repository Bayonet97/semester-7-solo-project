using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBackDoor : DoorInteractable
{
    public delegate void RockMovedAside();
    public static event RockMovedAside OnRockMovedAside;

    public override void Interact()
    {
        base.Interact();
        OnRockMovedAside();
    }
}
