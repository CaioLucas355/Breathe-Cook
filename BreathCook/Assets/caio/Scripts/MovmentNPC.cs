using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentNPC : MonoBehaviour
{



    [Header(" NPC")]
    public Collider2D NpcBx;

    public bool pedidoFT = false;

    
    private int pontoAtual;// QUAL PONTO NÓS ESTAMOS
    private Transform[] npcCadeira;

    [Header("Movimento do NPC")]
    [SerializeField] private float velocidadeDoNPC;

    private float ultimaPosiçãoX;

    //[Header("Ação do Cliente")]
    //public Transform balcao;
    //bool pedidoEntregue;
    //bool sentado;

    private void Start()
    {
        pontoAtual = 0;
        transform.position = GameManager.Instance.pontosDoCaixa[pontoAtual].position;
    }


    private void Update()
    {
        if ( pedidoFT == false)
        {
            MovimentarNPC();
            Debug.Log("pedido não feito");
        }
        else
        {
            IrParaCadeira();
        }
 
        EspelharHorizontal();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balcao"))
        {
            Debug.Log("pedido feito");
            pedidoFT = true;
            EscolherCadeira();
        }
    } //fazendo pedido
    
    public void EscolherCadeira()
    {
        for (int i = 0; i < GameManager.Instance.cadeirasOcupadas.Length; i++)
        {
            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraA;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;
                        break;
                }
                break; 
            }
        }
    }
    public void IrParaCadeira()
    {
        if (npcCadeira == GameManager.Instance.pontosCadeiraA)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraA[pontoAtual].position, velocidadeDoNPC * Time.deltaTime); 
            if (transform.position == GameManager.Instance.pontosCadeiraA[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraA.Length - 1)
                {
                    pontoAtual++;
                }
            }
            
     
        }
    }
    private void MovimentarNPC()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosDoCaixa[pontoAtual].position, velocidadeDoNPC * Time.deltaTime); // transform.position = ponto A = minha posição ; pontosDoCaixa[pontoAtual].position = ponto atual onde devo ir
        if (transform.position == GameManager.Instance.pontosDoCaixa[pontoAtual].position)// se a nossa posição é onde deviamos chegar
        {
            pontoAtual += 1;// aumentar em 1 e vai pro próximo ponto

            ultimaPosiçãoX = transform.localPosition.x;

            //if( pontoAtual >= pontosDoCaixa.Length)//   quando chega no limite da array
            // {
            //pontoAtual = 0;//retornar pro ponto original 
            // }
        }

    }

    private void EspelharHorizontal()
    {
        if (transform.localPosition.x < ultimaPosiçãoX)
        {
            transform.localScale = new Vector3(-4f, 5f, 5f);
        }
        else if (transform.localPosition.x > ultimaPosiçãoX)
        {
            transform.localScale = new Vector3(4f, 5f, 5f);
        }
    }


}
