using Assets.Scripts.Objects;
using UnityEngine;

public class MichaelInteractable : InteractableObject
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
