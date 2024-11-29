
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_tutorial : MonoBehaviour
{

    public static NPC_tutorial Instance;

    public GameObject pedido1;
    public GameObject pedido2;
    public GameObject pedido3;
    public GameObject pedido4;
    public GameObject pedido5;
    public GameObject pedido6;
    public GameObject pedido7;
    public GameObject pedido8;
    public GameObject pensamento;
    public GameObject Escuridao2;
    public GameObject ESC;

    public GameObject ingrediente1;
    public GameObject ingrediente2;
    public GameObject ingrediente3;
    public GameObject ingrediente4;



    int numero = 2;

    [Header("animacao")]

    public Animator animator;
    public SpriteRenderer sp;


    [Header("interacao botao")]
    public KeyCode botao = KeyCode.T;

    [Header(" NPC")]
    public Collider2D NpcBx;

    [Header("pratos")]
    [SerializeField] private GameObject[] pratos;

    public bool podeentregar = false;

    public int npedido;

    public int numeroCadeira;

    public bool pedidoFT = false;
    private int pontoAtual;// QUAL PONTO NÓS ESTAMOS
    private Transform[] npcCadeira;
    public bool esperandoPedido, comeuPartiu;
    [Header("Movimento do NPC")]
    [SerializeField] private float velocidadeDoNPC;

    comidafeita_tutorial comidaNaMesa;
    private float ultimaPosiçãoX;

    [Header("andando")]
    //public Transform balcao;
    public bool andando;
    //bool pedidoEntregue;
    [Header("sentado")]
    public bool sentado;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        andando = true;
        sentado = false;
        pontoAtual = 0;
        pratos = GameObject.FindGameObjectsWithTag("Prato");
    }


    private void Update()
    {
        if (pedidoFT == false & PLAYER_Tutorial.instamce.tutorial == false)
        {
            MovimentarNPC();
        }
        else
        {
            if (!esperandoPedido)
            {
                IrParaCadeira();
            }
            if (comeuPartiu == true)
            {

                IrEmbora();
            }
        }




        EspelharHorizontal();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balcao"))
        {
            //sp.flipX = true;
            npedido = 5;
            if (npedido == 0)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 1)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 2)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 3)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 4)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 5)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 6)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }
            if (npedido == 7)
            {
                pedido1.SetActive(true);
                pensamento.SetActive(true);
            }

            Debug.Log("pedido feito");
            pedidoFT = true;
            EscolherCadeira();
        }


        if (gameObject.transform == GameManager.Instance.pontosCadeiraA[1])
        {
            podeentregar = true;

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
                        numeroCadeira = 0;
                        pontoAtual = 0;
                        break;


                }
            }

        }
    }
    public void IrParaCadeira()
    {
        if (npcCadeira == GameManager.Instance.pontosCadeiraA)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraA[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraA[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraA.Length - 1)
                {
                    pontoAtual++;
                }
                else
                {
                    andando = false;
                    sentado = true;
                    
                    

                }


            }


        }
    

    }

    

    public void IrEmbora()
    {
        switch (numeroCadeira)
        {
            case 0:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraA[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraA[pontoAtual].position)
                {



                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraA.Length)
                {
                    Escuridao2.SetActive(true);
                    ESC.SetActive(true);
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;
                }
                break;

         
        }

    }

    public void ReceberComida(int numeroComida)
    {
        if (numeroComida == npedido)
        {
            PLAYER_Tutorial.instamce.segura = false;
            comidaNaMesa = PLAYER_Tutorial.instamce.comidaAtual.GetComponent<comidafeita_tutorial>();
            comidaNaMesa.tasegurando = false;

            comidaNaMesa.transform.position = GameManager.Instance.posicaoComidaMesa[numeroCadeira].position;
            pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;

            StartCoroutine(esperar());
            if (npedido == 0)
            {
                pedido1.SetActive(false);
                sentado = false;
            }
            if (npedido == 1)
            {
                pedido2.SetActive(false);
                sentado = false;

            }
            if (npedido == 2)
            {
                pedido3.SetActive(false);
                sentado = false;

            }
            if (npedido == 3)
            {
                pedido4.SetActive(false);
                sentado = false;

            }
            if (npedido == 4)
            {
                pedido5.SetActive(false);
                sentado = false;

            }
            if (npedido == 5)
            {
                pedido6.SetActive(false);
                sentado = false;

            }
            if (npedido == 6)
            {
                pedido7.SetActive(false);
                sentado = false;

            }
            if (npedido == 7)
            {
                pedido8.SetActive(false);
                sentado = false;

            }

           
        }
        else
        {
            cam_food_check.instance.IniciarDialogo();
            pedido1.SetActive(false);
            pedido2.SetActive(false);
            pedido3.SetActive(false);
            pedido5.SetActive(false);
            pedido6.SetActive(false);
            pedido7.SetActive(false);
            pedido8.SetActive(false);
            ingrediente1.SetActive(false);
            ingrediente2.SetActive(false);
            ingrediente3.SetActive(true);
            ingrediente4.SetActive(true);
            pedido4.SetActive(true);
        }
    }

    IEnumerator esperar()
    {
        esperandoPedido = true;
        yield return new WaitForSeconds(5);
        comeuPartiu = true;
        pontoAtual = 0;
    }

    public void MovimentarNPC()
    {
        float step = velocidadeDoNPC * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosDoCaixa[pontoAtual].position, step); // transform.position = ponto A = minha posição ; pontosDoCaixa[pontoAtual].position = ponto atual onde devo ir
        if (transform.position == GameManager.Instance.pontosDoCaixa[pontoAtual].position)// se a nossa posição é onde deviamos chegar
        {
            if (pontoAtual != GameManager.Instance.pontosDoCaixa.Length - 1)
            {
                pontoAtual++;

            }


            ultimaPosiçãoX = transform.localPosition.x;


        }
    }

    private void EspelharHorizontal()
    {


        if (andando == true & transform.localPosition.x < ultimaPosiçãoX)
        {
            animator.SetInteger("andando", 2);
            sp.flipX = false;
        }
        else if (andando == true & transform.localPosition.x > ultimaPosiçãoX)
        {
            animator.SetInteger("andando", 2);
            sp.flipX = true;
        }
        else if (sentado == true)
        {
            animator.SetInteger("andando", 0);
        }



    }
}
