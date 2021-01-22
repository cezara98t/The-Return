using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;
    public InputField textEntryField;
    public Text logText;
    public Text currentText;
    [TextArea]
    public string introText;
    public Action[] actions;
     
    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool addtive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        if (addtive)
            currentText.text += "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        logCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    private void logCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;
        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>"+textEntryField.text+"</color>";
    }

    private void ProcessInput(string input)
    {
        input = input.ToLower();
        char[] delimiter = { ' ' };
        string[] words = input.Split(delimiter);
        foreach(Action action in actions)
        {
            if(action.keyword.ToLower() == words[0])
            {
                if (words.Length > 1)
                {
                    action.RespondToInput(this, words[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }
        currentText.text = "Nothing happens! Having trouble? Type Help";
    }
}
