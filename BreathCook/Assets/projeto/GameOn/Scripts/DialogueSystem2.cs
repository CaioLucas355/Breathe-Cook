using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum STATE2
{
    DISABLED,
    WAITING,
    TYPING
}
public class DialogueSystem2 : MonoBehaviour
{
    public static DialogueSystem2 instance;

    public DialogueData dialogueData;

    public int currentText = 0; // posição da lista do scriptable object
    bool finished = false; // controlar  o momento que a conversa chegou ao fim

    public int conversaAtual;

    TypeTextAnimation typeText; // iniciar a nimação
    DialogueUI2 dialogueUI2;

    STATE1 state;


    void Awake()
    {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI2 = FindObjectOfType<DialogueUI2>();
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
    public void Next() // metodo par ao dialogo ser executado frase a frase
    {
        if (currentText == 0) // é a primeira frase?
        {
            dialogueUI2.Enable();
        }

        dialogueUI2.SetName(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text; // iniciar o type text atual e incrementar para a próxima frase

        if (currentText == dialogueData.talkScript.Count) finished = true; // checando se o dialogo chegou ao fim comparando a variavel current com o n total de elementos da lista

        typeText.StartTyping();// changing animation
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
                dialogueUI2.Disable();// caso termine fechar caixa
                state = STATE1.DISABLED;
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
            state = STATE1.WAITING;
        }
    }
}
