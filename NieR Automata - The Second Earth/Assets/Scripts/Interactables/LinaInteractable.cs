using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinaInteractable : InteractableObject
{

    public override void Interact()
    {
        if (!Dead)
        {
            base.Interact();
        }
        else if (Dead)
        {
            
            LevelLoader.LoadLevel("TrialScene");
           // InteractionFlows.Remove(InteractionFlows[0]);
        }
    }
}
