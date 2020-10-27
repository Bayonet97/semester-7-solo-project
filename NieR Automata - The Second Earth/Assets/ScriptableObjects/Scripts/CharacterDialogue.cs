using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DialogueState
{
    Disabled,
    Typing,
    Displayed
}
// BUGS: 
// - DialogueState goes to typing until shift is pressed
// - DialogueState goes Disabled after Displayed, even if there is more text
// - Dialogue Text stays after dialoge ends.

[CreateAssetMenu(fileName = "Player Character Dialogue")]
public class CharacterDialogue : ScriptableObject
{
    public delegate void DialogueStateChanged(DialogueState state);
    public static event DialogueStateChanged OnDialogueStateChanged;

    public delegate void TextToDisplayChanged(string text, string name);
    public static event TextToDisplayChanged OnTextToDisplayChanged;

    [SerializeField]
    private string _dialogueText;
    public string DialogueText { get=> _dialogueText; private set => _dialogueText = value; }

    public List<string> Dialogue;

    [SerializeField]
    private int _interactionCount;

    [SerializeField]
    private DialogueState _dialogueState = DialogueState.Disabled;


    public void OpenDialogue(List<string> dialogue, string name)
    {
        Dialogue = dialogue;
        _interactionCount = 0;

        UpdateTextToDisplay(Dialogue[_interactionCount], name);

        if (string.IsNullOrEmpty(Dialogue[_interactionCount])) return;

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
        ChangeDialogueState(DialogueState.Disabled);
        Clear();
    }

    private void UpdateTextToDisplay(string text, string name)
    {
        DialogueText = text;
        OnTextToDisplayChanged(text, name);
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
        if (_dialogueState == DialogueState.Disabled)
        {
            return;
        }
        else if (_dialogueState == DialogueState.Typing)
        {
            DoneTyping();
        }
        else if (_dialogueState == DialogueState.Displayed)
        {
            _interactionCount++;
            if (Dialogue.Count - 1 >= _interactionCount)
            {
                UpdateTextToDisplay(Dialogue[_interactionCount], null);
                ChangeDialogueState(DialogueState.Typing);
                return;
            }

            CloseDialogue();
        }
    }

    private void Clear()
    {
        _dialogueState = DialogueState.Disabled;
        Dialogue = null;
        DialogueText = "";
        _interactionCount = 0;
    }

    void OnDisable()
    {
        Clear();
    }
}
