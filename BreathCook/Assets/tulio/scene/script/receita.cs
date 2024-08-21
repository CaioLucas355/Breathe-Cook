using System.Collections;
using System.Collections.Generic;
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
    private int mandarqual = 0;
    public GameObject prato;
    //checar se oo ingrediente está na posição para ser feita a receita, caso não tiver ele retornara falso
    public bool [] combinacao;
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

                if (combinacao[3] == true)
                {
                    FinalizarCombinacao(0);
                }
                else
                {
                    combinacao[0] = true;
                }

                break;

        }
    
        // if (combinacao[1] != false)
        //  {
        //       FinalizarCombinacao(0);
        //   }
        //   else
        //   {
        //       combinacao[0] = true;
        //   }
        //   break;

        //        case 1:
        //   if (combinacao[0] != false)
        //    {
        //       FinalizarCombinacao(0);
        //   }
        //   else
        //   {
        //    combinacao[1] = true;
        // }
        //   break;
    }
     
        public void FinalizarCombinacao(int comb)
        {
           switch(comb)
        {
            case 0:
                Instantiate(comida[0], prato.transform.position, Quaternion.identity);
                Camera.main.transform.position = new Vector3(0.037f, 0.11f, -11f);

                break;
        }
        for (int i = 0; i < ingrediente.Length; i++)
        {
            ingrediente[i].gameObject.transform.position = ingrediente[i].posicaoinicial;
        }
        for (int i = 0; i < combinacao.Length; i++)
        {
            combinacao[i] = false;
        }  
        }
    //fazer o reset dos ingredientes e spanar o objeto na parte do restaurante
    }
