using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour

{
    public static NpcDialogue Instance;
    [Header("UI")]
    public TextMeshProUGUI nameNpc;
    //public Image imageNpc;
   // public Sprite spriteNpc;

    [Header("Dialogue")]

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private TextMeshProUGUI dialogueTextsave;

    [Header("NPC")]
    public string[] dialogueNpc1;
    public string[] dialogueNpc2;
    public string[] dialogueNpc3;
    public string[] dialogueNpc4;
    public string[] dialogueNpc5;
    public int dialogueIndex;
    public int dialogueNPC_n;


    [Header("Bools")]
    public bool readyToSpeak;
    public bool starDialogue;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dialoguePanel.SetActive(false);
        dialogueTextsave = dialogueText;
        
        if (dialogueNPC_n == 0)
        {
            dialogueText.text = dialogueNpc1[dialogueIndex];
            nameNpc.text = "Maria";
        }
        if (dialogueNPC_n == 1)
        {
            dialogueText.text = dialogueNpc2[dialogueIndex];
            nameNpc.text = "Ricardo";
        }
        if (dialogueNPC_n == 2)
        {
            dialogueText.text = dialogueNpc3[dialogueIndex];
            nameNpc.text = "Regina";
        }
        if (dialogueNPC_n == 3)
        {
            dialogueText.text = dialogueNpc4[dialogueIndex];
            nameNpc.text = "Marcelo";
        }
        if (dialogueNPC_n == 4)
        {
            dialogueText.text = dialogueNpc5[dialogueIndex];
            nameNpc.text = "Guilherme";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToSpeak)
        {
            if (starDialogue == false)
            {
                FindObjectOfType<Player_movement>().moveSpeed = 0;
                StarDialogue();
            }
            else if ( MovmentNPC.Instance.qualanimacao == 0 || MovmentNPC.Instance.qualanimacao == 1 || MovmentNPC.Instance.qualanimacao == 2 || MovmentNPC.Instance.qualanimacao == 3 || MovmentNPC.Instance.qualanimacao == 4)
            {
                Debug.Log("passou TT");
                    if (dialogueText.text == dialogueNpc1[dialogueIndex] && dialogueNPC_n == 0)
                    {
                      Debug.Log("aaa1");
                        NextDialogue();
                    }
                
                
                    
                    if ( dialogueText.text == dialogueNpc2[dialogueIndex] && dialogueNPC_n == 1)
                    {
                     Debug.Log("aaa2");
                      NextDialogue();
                    }
                
                
                   
                    if (dialogueText.text == dialogueNpc3[dialogueIndex] && dialogueNPC_n == 2)
                    {
                     Debug.Log("aaa3");
                     NextDialogue();
                    }
                
                
                   
                    if (dialogueText.text == dialogueNpc4[dialogueIndex] && dialogueNPC_n == 3)
                    {
                     Debug.Log("aaa4");
                     NextDialogue();
                    }
                
                
                
                    if (dialogueText.text == dialogueNpc5[dialogueIndex] && dialogueNPC_n == 4)
                    {
                     Debug.Log("aaa5");
                     NextDialogue();
                    }
                
            }
        }

        
    }
    public void NextDialogue()
    {
        dialogueIndex++;
        if(dialogueIndex < dialogueNpc1.Length|| dialogueIndex < dialogueNpc2.Length || dialogueIndex < dialogueNpc3.Length || dialogueIndex < dialogueNpc4.Length || dialogueIndex < dialogueNpc5.Length)
        {
            if (dialogueNPC_n == 0) 
            {
                dialogueText.text = dialogueNpc1[dialogueIndex];
            }
            if (dialogueNPC_n == 1)
            {
                dialogueText.text = dialogueNpc2[dialogueIndex];
            }
            if (dialogueNPC_n == 2)
            {
                dialogueText.text = dialogueNpc3[dialogueIndex];
            }
            if (dialogueNPC_n == 3)
            {
                dialogueText.text = dialogueNpc4[dialogueIndex];
            }
            if (dialogueNPC_n == 4)
            {
                dialogueText.text = dialogueNpc5[dialogueIndex];
            }
            // StartCoroutine(ShowDialogue());
        }
        else if (dialogueIndex >= dialogueNpc1.Length || dialogueIndex >= dialogueNpc2.Length || dialogueIndex >= dialogueNpc3.Length || dialogueIndex >= dialogueNpc4.Length || dialogueIndex > dialogueNpc5.Length)
        {
            dialoguePanel.SetActive(false);
            starDialogue = false;
            dialogueIndex = 0;
            dialogueNPC_n++;
            dialogueText = dialogueTextsave;
            FindObjectOfType<Player_movement>().moveSpeed = 5f;
            Debug.Log("JSADHDFIOUAS" + dialogueIndex);
        }
    }
    public void StarDialogue()
    {
       
        starDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        // StartCoroutine(ShowDialogue());

    }
    /* IEnumerator ShowDialogue()
     {



         foreach (char letter in dialogueNpc1[dialogueIndex])
         {
             dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);

         }
         foreach (char letter in dialogueNpc2[dialogueIndex])
         {
             dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);
         }
         foreach (char letter in dialogueNpc3[dialogueIndex])
         {
             dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);
         }
         foreach (char letter in dialogueNpc4[dialogueIndex])
         {
             dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);
         }
         foreach (char letter in dialogueNpc5[dialogueIndex])
         {
             dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);
         }
     } */
}
