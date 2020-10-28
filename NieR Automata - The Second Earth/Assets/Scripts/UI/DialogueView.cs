using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    public Text dialogueText;
    public Text dialogueName;
    private string _textToDisplay;

    [SerializeField] private int _timeBetweenLetters;

    [SerializeField] private CharacterDialogue _characterDialogue;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void UpdateToStateOfDialogue(DialogueState dialogueState)
    {
        if(dialogueState == DialogueState.Disabled && this.gameObject.activeSelf == true)
        {
            _textToDisplay = "";
            this.gameObject.SetActive(false);
        }
        else if(dialogueState == DialogueState.Typing)
        {
            DisplayText();
        }
    }

    public void UpdateTextToDisplay(string text, string name)
    {
        _textToDisplay = text;
        if (!string.IsNullOrEmpty(name)) 
        {
            dialogueName.text = name;
        } 
    }

    private void DisplayText()
    {
        this.gameObject.SetActive(true);

        _textToDisplay = _textToDisplay.Replace("<br> ", System.Environment.NewLine);
        char[] charArr = _textToDisplay.ToCharArray();
        string charText = "";
        foreach (char ch in charArr)
        {
                charText = charText + ch;
                dialogueText.text = _textToDisplay; 
        }
        _characterDialogue.DoneTyping();
        _textToDisplay = "";
    }

    public void OnEnable()
    {
       CharacterDialogue.OnDialogueStateChanged += UpdateToStateOfDialogue;
       CharacterDialogue.OnTextToDisplayChanged += UpdateTextToDisplay;
    }

    public void OnDisable()
    {
    }
}
