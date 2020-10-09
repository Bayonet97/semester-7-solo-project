using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private PlayerCharacterBase character;

    public CharacterInteraction(PlayerCharacterBase _character)
    {
        character = _character;
    }

    internal void InteractWithObject(InteractableObject objectOfInteraction)
    {
        // CheckSpecificObjectToInteractWith(objectOfInteraction);

        objectOfInteraction.Interact();

        if(objectOfInteraction.TextToShow != "" && objectOfInteraction != null)
            character.ShowDialogue(objectOfInteraction.TextToShow);
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
