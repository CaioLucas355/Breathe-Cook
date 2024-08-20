using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//aparecer no spector
public struct Dialogue
{
    public string name;//NOME DE QUEM EST� FALANDO
    [TextArea(5,10)] // aumentar a caixa de texto
    public string text;//OQ EST� FALANDO
}


[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/TalkScript", order = 1)]//criar scriptable objects por meio do menu de op��es
public class DialogueData : ScriptableObject
{
    public List<Dialogue> talkScript;//todo o conteudo da conversa
}
