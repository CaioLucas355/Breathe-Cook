using System.Collections;
using UnityEngine;

public class gerenciadorNPC : MonoBehaviour
{
    public static gerenciadorNPC instance;

    public int veio1 = 10;
    public int veio2 = 10;
    public int veio3 = 10;
    public int veio4 = 10;
    public int veio5 = 10;
    public bool podeVoltarAleatorio = false;

    private int diaAtual;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        diaAtual = word.instamce.dia;
        StartCoroutine(GerenciarDia());
    }

    IEnumerator GerenciarDia()
    {
        while (true)
        {
            if (word.instamce.dia != diaAtual)
            {
                diaAtual = word.instamce.dia;

                if (diaAtual >= 1 && diaAtual <= 5)
                {
                    ResetarValores();
                    StartCoroutine(Npcs());
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    void ResetarValores()
    {
        veio1 = veio2 = veio3 = veio4 = veio5 = 10;
        podeVoltarAleatorio = false;
    }

    IEnumerator Npcs()
    {
        while (!(veio1 == 1 && veio2 == 2 && veio3 == 3 && veio4 == 4 && veio5 == 5))
        {
            yield return new WaitForSeconds(3);
        }

        podeVoltarAleatorio = true;
    }
}