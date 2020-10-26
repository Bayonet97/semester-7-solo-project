using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Character Interaction")]
public class CharacterInteraction : ScriptableObject
{
    public delegate void DialogueHasText(List<string> text);
    public static event DialogueHasText OnDialogueHasText;

    internal void InteractWithObject(InteractableObject objectOfInteraction)
    {
        // CheckSpecificObjectToInteractWith(objectOfInteraction);

        objectOfInteraction.Interact();

        if(objectOfInteraction.InteractionFlows[0] != null && objectOfInteraction != null)
            OnDialogueHasText(objectOfInteraction.InteractionFlows[0].Dialogue);
    }

    // TO DO: Change the way the character checks for a specific object to not rely on their name.
/*    private void CheckSpecificObjectToInteractWith(InteractableObject objectOfInteraction)
    {
        switch (objectOfInteraction)
        {
            case DefaultInteractable di:
                di.Interact();
                break;
            case ButtonInteractable bi
            default:
                throw new ArgumentException(
                message: "object interaction is not implemented yet: ", paramName: objectOfInteraction.name);
        }

    }*/
}
