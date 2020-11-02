using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvictionResultInteractable : InteractableObject
{
    [SerializeField]
    private NineS nines;

    [SerializeField]
    private CharacterInteraction interaction;

    private SuspectInteractable sus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        if(InteractionFlows.Count > 1){
            switch (sus.Name)
            {
                case "Harold the Rich":
                    InteractionFlows.Remove(InteractionFlows[2]);
                    InteractionFlows.Remove(InteractionFlows[1]);
                    break;
                case "Sarah the Homeless":
                    InteractionFlows.Remove(InteractionFlows[2]);
                    InteractionFlows.Remove(InteractionFlows[0]);
                    break;
                case "2B the Killer":
                    InteractionFlows.Remove(InteractionFlows[1]);
                    InteractionFlows.Remove(InteractionFlows[0]);
                    break;
                default:
                    break;
            }
        }

        base.Interact();
    }

    public void OnEnable()
    {
        nines.OnSuspectConvicted += setSuspect;
    }

    private void setSuspect(SuspectInteractable suspect)
    {
        sus = suspect;
        interaction.InteractWithObject(this);
    }
}
