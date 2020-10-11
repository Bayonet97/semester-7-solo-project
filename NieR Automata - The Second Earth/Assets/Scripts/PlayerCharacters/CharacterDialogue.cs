using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueState
{
    Disabled,
    Typing,
    Displayed
}

public class CharacterDialogue : MonoBehaviour
{
    public delegate void DialogueStateChanged(DialogueState state);
    public static event DialogueStateChanged OnDialogueStateChanged;
    
    public delegate void TextToDisplayChanged(string text);
    public static event TextToDisplayChanged OnTextToDisplayChanged;

    public string DialogueText { get; private set; }
    private DialogueState _dialogueState = DialogueState.Disabled;

    [SerializeField] private PlayerCharacterBase character;

    public void OpenDialogue(string dialogue)
    {
        UpdateTextToDisplay(dialogue);

        if (string.IsNullOrEmpty(dialogue)) return;

        character.ChangePausedState(true);
        ChangeDialogueState(DialogueState.Typing);
    }
    public void NextDialogue()
    {
        ChangeDialogueState(DialogueState.Typing);
    }

    public void DoneTyping()
    {
        // Instantly show all text call to view
        ChangeDialogueState(DialogueState.Displayed);
    }

    public void CloseDialogue()
    {
        character.ChangePausedState(false);
        ChangeDialogueState(DialogueState.Disabled);
    }

    private void UpdateTextToDisplay(string text)
    {
        DialogueText = text;
        OnTextToDisplayChanged(text);
    }

    private void ChangeDialogueState(DialogueState state)
    {
        _dialogueState = state;
        OnDialogueStateChanged(state);
    }

    public DialogueState GetDialogueState()
    {
        return _dialogueState;
    }

    internal void NextState()
    {
        if(_dialogueState == DialogueState.Disabled)
        {
            return;
        }
        else if(_dialogueState == DialogueState.Typing)
        {
            DoneTyping();
        }
        else if(_dialogueState == DialogueState.Displayed)
        {
            CloseDialogue();
        }
    }

}
