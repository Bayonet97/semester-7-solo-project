using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManInteractable : InteractableObject
{
    public delegate void OpeningDoor();
    public static event OpeningDoor OnOpeningDoor;

    private bool rockMoved = false;

    public override void Interact()
    {
        if (rockMoved)
        {
            OnOpeningDoor();
        }
    }
    private void RockMovedAside()
    {
        rockMoved = true;
        InteractionFlows.Remove(InteractionFlows[0]);
        OnOpeningDoor();
    }

    public void OnEnable()
    {
        HomeBackDoor.OnRockMovedAside += RockMovedAside;
    }
}
