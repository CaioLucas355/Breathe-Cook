using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentNPC : MonoBehaviour
{
    

    [Header("Caminho do NPC")]
    [SerializeField] private Transform[] pontosDoCaixa;
    [SerializeField] private Transform[] pontosAtendido;
    [SerializeField] private Transform[] pontosCadeiraA;
    [SerializeField] private Transform[] pontosCadeiraB;
    [SerializeField] private Transform[] pontosCadeiraC;
    [SerializeField] private Transform[] pontosCadeiraD;
    [SerializeField] private Transform[] pontosCadeiraE;
    [SerializeField] private Transform[] pontosCadeiraF;
    [SerializeField] private Transform[] pontosCadeiraG;
    [SerializeField] private Transform[] pontosCadeiraH;
    [SerializeField] private Transform[] pontosCadeiraI;
    [SerializeField] private Transform[] pontosCadeiraJ;
    [SerializeField] private Transform[] pontosCadeiraK;
    [SerializeField] private Transform[] pontosCadeiraL;

    private int pontoAtual;// QUAL PONTO N�S ESTAMOS


    [Header("Movimento do NPC")]
    [SerializeField] private float velocidadeDoNPC;

    private float ultimaPosi��oX;
    
    [Header("A��o do Cliente")]
    public Transform balcao;
    bool pedidoEntregue;
    bool sentado;

   private void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaixa[pontoAtual].position;
    }

    
    private void Update()
    {
        MovimentarNPC();
        EspelharHorizontal();
    }
    private void MovimentarNPC()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaixa[pontoAtual].position, velocidadeDoNPC * Time.deltaTime); // transform.position = ponto A = minha posi��o ; pontosDoCaixa[pontoAtual].position = ponto atual onde devo ir
        if (transform.position == pontosDoCaixa[pontoAtual].position )// se a nossa posi��o � onde deviamos chegar
        {
            pontoAtual += 1;// aumentar em 1 e vai pro pr�ximo ponto

            ultimaPosi��oX = transform.localPosition.x;

           //if( pontoAtual >= pontosDoCaixa.Length)// condi��o quando chega no limite da array
          // {
                //pontoAtual = 0;//retornar pro ponto original 
          // }
        }
    
    }

    private void EspelharHorizontal()
    {
        if (transform.localPosition.x < ultimaPosi��oX)
        {
            transform.localScale = new Vector3(-4f, 5f, 5f);
        }
        else if (transform.localPosition.x > ultimaPosi��oX)
        {
            transform.localScale = new Vector3(4f, 5f, 5f);
        }
    }
  
}   
