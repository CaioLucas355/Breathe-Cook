using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_food_check : MonoBehaviour
{
    public static cam_food_check instance;

    AuudioManager audioManager;

    public int chamou;

    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();

        instance = this;
    }
    void Start()
    {
        chamou = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IniciarDialogo()
    {
        if (chamou == 0)
        {
            audioManager.PlaySFX(audioManager.oi);
            DialogueSystem1.instance.Next();
            chamou = 1;
        }
    }



}
