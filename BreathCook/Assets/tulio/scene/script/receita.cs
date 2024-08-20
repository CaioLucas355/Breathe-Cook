using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receita : MonoBehaviour
{
    public static receita instance;

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
                if (combinacao[1] != false)
                {
                    FinalizarCombinacao(0);
                }
                else
                {
                    combinacao[0] = true;
                }
                break;

                     case 1:
                if (combinacao[0] != false)
                {
                    FinalizarCombinacao(0);
                }
                else
                {
                    combinacao[1] = true;
                }
                break;
        }
    }
    public void FinalizarCombinacao(int combinacao)
    {

    }
    //fazer o reset dos ingredientes e spanar o objeto na parte do restaurante
}
