using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class receita : MonoBehaviour
{
    public static receita instance;
    [Header("botao para mandar comida")]
    public KeyCode botaoparamandarcomida = KeyCode.G;
    [Header("botao para continuar fazendo comida")]
    public KeyCode botaoparacontinuarfazendo = KeyCode.H;
    public GameObject[] comida;
    public interacaocozinha[] ingrediente;
    public GameObject prato;


    
    //checar se oo ingrediente está na posição para ser feita a receita, caso não tiver ele retornara falso
    public bool[] combinacao;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void fazerbebida(int ingrediente)
    {
        switch (ingrediente)
        {
            case 0:
                //verifica se a camomila ja esta posicionada
                //se tiver ele completa a receita cha de camomila
                //senao ele coloca a agua como verdadeiro para sinalizar que esta na posicao para fazer a receita
                if (combinacao[1] == true)
                {
                    FinalizarCombinacao(0);
                    
                }
                else if (combinacao[2] == true)
                {
                    FinalizarCombinacao(1);
                    
                }
                else if (combinacao[5] == true)
                {
                    FinalizarCombinacao(3);
                }
                else
                {
                    combinacao[0] = true;
                }
                break;


            case 1:
                if (combinacao[0] == true)
                {
                    FinalizarCombinacao(0);
                }
                else
                {
                    combinacao[1] = true;
                }
                break;




            case 2:

                if (combinacao[3] == true && combinacao[4] == true)
                {
                    FinalizarCombinacao(2);
                }
                else if (combinacao[0] == true)
                {
                    FinalizarCombinacao(1);
                }
                else
                {
                    combinacao[2] = true;
                }

                break;


            case 3:

                if (combinacao[2] == true && combinacao[4] == true)
                {
                    FinalizarCombinacao(2);
                }
                else
                {
                    combinacao[3] = true;
                }

                break;


            case 4:

                if (combinacao[2] == true && combinacao[3] == true)
                {
                    FinalizarCombinacao(2);
                }
                else
                {
                    combinacao[4] = true;
                }

                break;
            case 5:

                if (combinacao[0] == true)
                {
                    FinalizarCombinacao(3);
                }
                else
                {
                    combinacao[5] = true;
                }

                break;

        }


    }

    public void fazerentrada(int ingrediente)
    {
        switch (ingrediente)
        {



            case 8:
                if (combinacao[6] == true && combinacao[7] == true)
                {
                    FinalizarCombinacao(4);
                   
                }
                else
                {
                    combinacao[8] = true;
                }
                break;




            case 6:

                if (combinacao[8] == true && combinacao[7] == true)
                {
                    FinalizarCombinacao(4);
                   
                }
                else
                {
                    combinacao[6] = true;
                }

                break;


            case 7:

                if (combinacao[6] == true && combinacao[8] == true)
                {
                    FinalizarCombinacao(4);
                   
                }
                else
                {
                    combinacao[7] = true;
                }

                break;


            case 9:

                if (combinacao[10] == true )
                {
                    FinalizarCombinacao(5);
                  
                }
                else
                {
                    combinacao[9] = true;
                }

                break;
            case 10:

                if (combinacao[9] == true )
                {
                    FinalizarCombinacao(5);
                   
                }
                else
                {
                    combinacao[10] = true;
                }

                break;

            

        }


    }

    public void fazersobremesa(int ingrediente)
    {
        switch (ingrediente)
        {
            


            case 11:
                if (combinacao[12] == true && combinacao[13] == true)
                {
                    FinalizarCombinacao(6);
                }
                else if (combinacao[12] == true && combinacao[14] == true)
                {
                    FinalizarCombinacao(7);
                }
                else
                {
                    combinacao[11] = true;
                }
                break;

            case 12:
                if (combinacao[11] == true && combinacao[13] == true)
                {
                    FinalizarCombinacao(6);
                }
                else if (combinacao[11] == true && combinacao[14] == true)
                {
                    FinalizarCombinacao(7);
                }
                else
                {
                    combinacao[12] = true;
                }
                break;

            case 13:
                if (combinacao[12] == true && combinacao[11] == true)
                {
                    FinalizarCombinacao(6);
                }
                else
                {
                    combinacao[13] = true;
                }
                break;

            case 14:
                if (combinacao[12] == true && combinacao[11] == true)
                {
                    FinalizarCombinacao(7);
                }
                else
                {
                    combinacao[14] = true;
                }
                break;


           
        }


    }

    public void FinalizarCombinacao(int comb)
    {

        Instantiate(comida[comb], prato.transform.position, Quaternion.identity);
        Player_movement.instamce.movevolta = true;
        ReceitaAbrir.Instance.FecharReceitas();
        
        StartCoroutine(esperar());
        for (int i = 0; i < combinacao.Length; i++)
        {
            combinacao[i] = false;
        }
    }
    //fazer o reset dos ingredientes e spanar o objeto na parte do restaurante

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < ingrediente.Length; i++)
        {
            ingrediente[i].gameObject.transform.position = ingrediente[i].posicaoinicial;
        }

    }



}
