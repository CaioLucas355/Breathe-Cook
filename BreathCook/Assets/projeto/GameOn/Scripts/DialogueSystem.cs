using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}
public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;

    public bool terminafala = false;
    public DialogueData dialogueData;
    public int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;


     void Awake()
    {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinishe;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        state = STATE.DISABLED;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == STATE.DISABLED) return;
        switch (state)
        {
            case STATE.WAITING:
                Waiting();
                break;
           case STATE.TYPING:
                Typing();
                break;
        }
    }
   public  void Next()
    {
        terminafala = false;
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;
        
        if (currentText == dialogueData.talkScript.Count) finished = true;
        
        typeText.StartTyping();
        state = STATE.TYPING;
    }
    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }
    void Waiting()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            if (!finished)
            {
                Next();
            }
            else
            {   
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentText = 0;
                finished = false;
            }
        }
    }
    void Typing()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
