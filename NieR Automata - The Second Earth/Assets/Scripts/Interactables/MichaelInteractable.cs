using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelInteractable : InteractableObject
{
    public delegate void OpeningDoor();
    public static event OpeningDoor OnOpeningDoor;
    [SerializeField]
    CharacterDialogue characterDialogue;
    public override void Interact()
    {
        if (!Dead)
        {
            base.Interact();
        }
        else if (Dead)
        {
            InteractionFlows.Remove(InteractionFlows[0]);
            LevelLoader.LoadLevel("TrialScene");
            
           // InteractionFlows.Remove(InteractionFlows[0]);
        }
    }

    public void OnEnable()
    {
        
    }
}
