using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;

public class word : MonoBehaviour
{
    public static word instamce;

    public int dia;
    public int time = 6;
    public bool ta_de_noite;

    [Header("TEMPO DA HORA")]
    public int tempodahora;

    public GameObject noite;
    private void Awake()
    {

        instamce = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(tempo());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator tempo()
    {
       
        yield return new WaitForSeconds(tempodahora);
        time++;
        if (time == 24)
        {
            dia++;
            time = 0;
            Debug.Log("passou 1 dia");
        }


        if (time == 18)
        {
            noite.SetActive(true);
            ta_de_noite = true;
        }
        if (time == 5)
        {
            noite.SetActive(false);
            ta_de_noite = false;
        }

       StartCoroutine(tempo());
    }
}
