using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour

{

    public MovmentNPC npc;

    public int h;

    public static NpcDialogue Instance;
    public TextMeshProUGUI nameNpc;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dia1;
    public string[] dia2;
    public string[] dia3;
    public string[] dia4;
    public string[] dia5;
    public string[] dia6;
    public int dialogoNumero;
    public int numero = 0;
    public bool esperar;
    public bool pressed;
    public bool falando;

    public bool esperarDialogo;

    Dictionary<int, string[]> dialogueList = new Dictionary<int, string[]>();


    private void Awake()
    {
        
        Instance = this;
    }
    void Start()
    {

        dialoguePanel.SetActive(false);
        numero = 0;

        dialogueList.Add(0, dia1);
        dialogueList.Add(1, dia2);
        dialogueList.Add(2, dia3);
        dialogueList.Add(3, dia4);
        dialogueList.Add(4, dia5);
        dialogueList.Add(5, dia6);
    }

    void Update()
    {
        MostrarDialogo(dialogueList[dialogoNumero]);
    }
    public void MostrarDialogo(string[] dialogo)
    {
        if (Player_movement.instamce.readyToSpeak == true && esperar == false && !npc.jaFalou)
        {
            Player_movement.instamce.moveSpeed = 0;
            dialoguePanel.SetActive(true);
            dialogueText.text = dialogo[numero];
            
            if (Input.GetKey(KeyCode.E) && esperarDialogo)
            {
                numero++;
                StartCoroutine(audio());
                StartCoroutine(EsperarDialogo());
            }
        }
        if (numero >= dialogo.Length)
        {
            dialoguePanel.SetActive(false);
            numero = 0;
            StartCoroutine(Esperar());
            Player_movement.instamce.moveSpeed = 5;
            npc.emanuelImage.SetActive(false);
            h++;
            npc.jaFalou = true;
        }
        
    } 
    IEnumerator EsperarDialogo()
    {
        esperarDialogo = false;
        yield return new WaitForSeconds(0.2f);
        esperarDialogo = true;
    }
    IEnumerator Esperar()
    {
        esperar = true;
        yield return new WaitForSeconds(1);
        esperar = false;
    }
    IEnumerator audio()
    {
        yield return null;
    }
}
