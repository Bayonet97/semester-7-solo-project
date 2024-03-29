﻿using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinaInteractable : InteractableObject
{
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
}
