using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum STATE1
{
    DISABLED,
    WAITING,
    TYPING
}
public class DialogueSystem1 : MonoBehaviour
{
    public static DialogueSystem1 instance;

    public DialogueData[] dialogueData;
    public int currentText = 0;
    bool finished = false;
    public int conversaAtual;
    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE1 state;


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
        state = STATE1.DISABLED;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == STATE1.DISABLED) return;
        switch (state)
        {
            case STATE1.WAITING:
                Waiting();
                break;
            case STATE1.TYPING:
                Typing();
                break;
        }
    }
    public void Next()
    {
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData[conversaAtual].talkScript[currentText].name);

        typeText.fullText = dialogueData[conversaAtual].talkScript[currentText++].text;

        if (currentText == dialogueData[conversaAtual].talkScript.Count) finished = true;

        typeText.StartTyping();
        state = STATE1.TYPING;
    }
    void OnTypeFinishe()
    {
        state = STATE1.WAITING;
    }
    void Waiting()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!finished)
            {
                Next();
            }
            else
            {
                dialogueUI.Disable();
                state = STATE1.DISABLED;
                currentText = 0;
                finished = false;
                conversaAtual++;
            }
        }
    }
    void Typing()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            typeText.Skip();
            state = STATE1.WAITING;
        }
    }
}
