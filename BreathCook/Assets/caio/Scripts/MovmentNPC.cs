using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class MovmentNPC : MonoBehaviour
{//

    

    [Header(" NPC")]
    public Collider2D NpcBx;
    

    public bool pedidoFT = false;

    private int pontoatualembora = 0;
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
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraB;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraC;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraD;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraE;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraF;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraG;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
            }

            if (GameManager.Instance.cadeirasOcupadas[i] == false)
            {
                switch (i)
                {
                    case 0:
                        npcCadeira = GameManager.Instance.pontosCadeiraH;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        pontoAtual = 0;

                        break;
                }
                break;
            }
            else if (GameManager.Instance.cadeirasOcupadas[i] == true)
            {
                i++;
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
                    
                    if (pontoAtual == 2)
                    {
                        Debug.Log("3ponto");
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                       
                        


                        esperar();
 
                        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraA[pontoatualembora].position, velocidadeDoNPC * Time.deltaTime);
                        Debug.Log("AA");
                            pontoatualembora++;
                       

                        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraA[pontoatualembora].position, velocidadeDoNPC * Time.deltaTime);
                        pontoatualembora++;
                        
                        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraA[pontoatualembora].position, velocidadeDoNPC * Time.deltaTime);
                        pontoatualembora++;
                        
                        if (pontoatualembora >= 2 && transform.position == GameManager.Instance.iremboraA[2].transform.position)
                        {
                            Destroy(gameObject);
                        }
                            
                    }
                }
            }
            
     
        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraB)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraB[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraB[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraB.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraB[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                          transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraB[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraB.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraC)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraC[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraC[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraC.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraC[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                          transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraC[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraC.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraD)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraD[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraD[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraD.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraD[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                          transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraD[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraD.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraE)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraE[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraE[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraE.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraE[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                         transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraE[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraE.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraF)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraF[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraF[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraF.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraF[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                         transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraF[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraF.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraG)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraG[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraG[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraG.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraG[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                         transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraG[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraG.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraH)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraH[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            if (transform.position == GameManager.Instance.pontosCadeiraH[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraH.Length - 1)
                {
                    pontoAtual++;
                    if (pontoAtual == 3 && transform.position == GameManager.Instance.pontosCadeiraH[pontoAtual].position)
                    {
                        //if (recebeucomida.transform.posision == cadeiraA.transform.posision) {                       public Gameobject cadeiraA;
                        esperar();
                          transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraH[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                        if (pontoAtual >= GameManager.Instance.iremboraH.Length)
                        {
                            Destroy(gameObject);
                        }

                    }
                }
            }


        }
        
    }

   
    IEnumerator esperar()
    { 
        yield return new WaitForSeconds(5);
    }

    public void MovimentarNPC()
    {
        float step = velocidadeDoNPC * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosDoCaixa[pontoAtual].position, step); // transform.position = ponto A = minha posição ; pontosDoCaixa[pontoAtual].position = ponto atual onde devo ir
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
