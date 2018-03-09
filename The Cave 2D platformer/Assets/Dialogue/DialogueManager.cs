using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //allows us to call upon the dialogue manager(enable/disable it).
    public GameObject DialogueBox;

    //call upon our UI text so we can change it.
    public Text DialogueText;

    //allows us to know if dialogue box is active or not.
    public bool DialogueActive;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //this disables the textbox by using the key(rightshift).
        if (DialogueActive && Input.GetKeyDown(KeyCode.RightShift))
        {
            DialogueBox.SetActive(false);
            DialogueActive = false;
        }	
	}

    //this method allows the box to appear via a trigger(distance from AI).
    public void ShowBox(string dialogue)
    {
        DialogueActive = true;
        DialogueBox.SetActive(true);
        DialogueText.text = dialogue;
    }
}
