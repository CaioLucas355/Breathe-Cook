using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//aparecer no spector
public struct Dialogue
{
    public string name;//NOME DE QUEM ESTÁ FALANDO
    [TextArea(5,10)] // aumentar a caixa de texto
    public string text;//OQ ESTÁ FALANDO
}


[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/TalkScript", order = 1)]//criar scriptable objects por meio do menu de opções
public class DialogueData : ScriptableObject
{
    public List<Dialogue> talkScript;//todo o conteudo da conversa
}
