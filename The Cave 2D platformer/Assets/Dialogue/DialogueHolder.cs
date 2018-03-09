using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    //generates text you want player/AI to say when triggered.
    public string Dialogue;

    private DialogueManager DialogueMan;

    // Use this for initialization
	void Start ()
    {
        //finds the text you want. Unlimited text possible.
        DialogueMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                DialogueMan.ShowBox(Dialogue);
            }
        }
    }
}
