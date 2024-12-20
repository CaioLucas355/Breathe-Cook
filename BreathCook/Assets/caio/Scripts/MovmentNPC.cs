
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovmentNPC : MonoBehaviour
{
    AuudioManager audioManager;

    public int dialogo;
    public int h = 1;
    public int wait;

    public List<GameObject> pedidos;
    public int[] pedidoList;
    [SerializeField] private GameObject pensamento;

    public int qualanimacao;

    public RuntimeAnimatorController[] NPCAniamtors;

    Animator animacaoATUAL;

    int numero = 2;

    [Header("animacao")]
    
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
    private int pontoAtual;// QUAL PONTO N�S ESTAMOS
    private Transform[] npcCadeira;
    public bool esperandoPedido, comeuPartiu;

    [Header("Movimento do NPC")]
    [SerializeField] private float velocidadeDoNPC;

    comidafeita comidaNaMesa;
    private float ultimaPosi��oX;

    [Header("andando")]
    //public Transform balcao;
    public bool andando;
    //bool pedidoEntregue;
    [Header("sentado")]
    public bool sentado;

    [Header("vai vir o")]
    public int vir_o_;
    public int numeroDialogo;

    [Header("Conversa Antes")]
    public GameObject emanuelImage;

    public bool historia;
    public bool jaFalou;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();

    }

    private void Start()
    {
        andando = true;
        sentado = false;
        pontoAtual = 0;
        pratos = GameObject.FindGameObjectsWithTag("Prato");
        numeroDialogo = gerarNPC.instance.npcsDialogo;
        animacaoATUAL = GetComponent<Animator>();
        if (!historia)
        {
            animacaoATUAL.runtimeAnimatorController = NPCAniamtors[Random.Range(1, NPCAniamtors.Length)];
        }
        else
        {
            animacaoATUAL.runtimeAnimatorController = NPCAniamtors[0];
        }
    }
    private void Update()
    {
        if (pedidoFT == false)
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
        //ahsgdfhavsdjhabvsda
        if (collision.gameObject.CompareTag("balcao") && wait == 0)
        {
            audioManager.PlaySFX(audioManager.FazendoPedido);
            npedido = Random.Range(0, 6);
            if (npedido == pedidoList[npedido])
            {
                pedidos[npedido].SetActive(true);
                pensamento.SetActive (true);
                if (historia)
                {
                    emanuelImage.gameObject.SetActive(true);
                }
            }
            Debug.Log("pedido feito");
            pedidoFT = true;
            EscolherCadeira();
            StartCoroutine(Esperar());
        }
        //asukjhdgjayhsgdahsgd


        if (gameObject.transform == GameManager.Instance.pontosCadeiraA[1])
        {
            podeentregar = true;
            
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraB[2])
        {
            podeentregar = true;
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraC[2])
        {
            podeentregar = true;
            
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraD[3])
        {
            podeentregar = true;
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraE[1])
        {
            podeentregar = true;
           
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraF[2])
        {
            podeentregar = true;
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraG[2])
        {
            podeentregar = true;
           
        }
        if (gameObject.transform == GameManager.Instance.pontosCadeiraH[3])
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
                    case 1:
                        npcCadeira = GameManager.Instance.pontosCadeiraB;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 1;
                        pontoAtual = 0;
                        break;
                    case 2:
                        npcCadeira = GameManager.Instance.pontosCadeiraC;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 2;
                        pontoAtual = 0;
                        break;
                    case 3:
                        npcCadeira = GameManager.Instance.pontosCadeiraD;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 3;
                        pontoAtual = 0;
                        break;
                    case 4:
                        npcCadeira = GameManager.Instance.pontosCadeiraE;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 4;
                        pontoAtual = 0;
                        break;
                    case 5:
                        npcCadeira = GameManager.Instance.pontosCadeiraF;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 5;
                        pontoAtual = 0;
                        break;
                    case 6:
                        npcCadeira = GameManager.Instance.pontosCadeiraG;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 6;
                        pontoAtual = 0;
                        break;
                    case 7:
                        npcCadeira = GameManager.Instance.pontosCadeiraH;
                        GameManager.Instance.cadeirasOcupadas[i] = true;
                        numeroCadeira = 7;
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
        if (npcCadeira == GameManager.Instance.pontosCadeiraB)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraB[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraB[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraB.Length - 1)
                {
                    pontoAtual++;     
                }
                else
                {
                    andando = false;
                    sentado = true;
                    sp.flipX = false;
                      
                }
            }
        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraC)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraC[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraC[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraC.Length - 1)
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
        if (npcCadeira == GameManager.Instance.pontosCadeiraD)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraD[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraD[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraD.Length - 1)
                {
                    pontoAtual++;
                }
                else
                {
                    andando = false;
                    sentado = true;
                    sp.flipX = false;
                }
            }
        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraE)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraE[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraE[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraE.Length - 1)
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
        if (npcCadeira == GameManager.Instance.pontosCadeiraF)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraF[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraF[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraF.Length - 1)
                {
                    pontoAtual++;
                }
                else
                {
                    andando = false;
                    sentado = true;
                    sp.flipX = false;
                }
            }
        }
        if (npcCadeira == GameManager.Instance.pontosCadeiraG)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraG[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraG[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraG.Length - 1)
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
        if (npcCadeira == GameManager.Instance.pontosCadeiraH)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosCadeiraH[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
            andando = true;
            if (transform.position == GameManager.Instance.pontosCadeiraH[pontoAtual].position)
            {
                if (pontoAtual != GameManager.Instance.pontosCadeiraH.Length - 1)
                {
                    pontoAtual++;
                }
                else
                {
                    andando = false;
                    sentado = true;
                    sp.flipX = false;
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

                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f,900f,1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual -1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;

            case 1:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraB[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraB[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraB.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual -1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 2:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraC[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraC[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraC.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 3:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraD[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraD[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraD.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 4:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraE[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraE[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraE.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 5:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraF[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraF[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraF.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 6:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraG[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraG[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraG.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                            gerarNPC.instance.IniciarSpawn();
                            NpcDialogue.Instance.dialogoNumero++;
                            NpcDialogue.Instance.numero = 0;
                            NpcDialogue.Instance.h++;
                            if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
            case 7:
                andando = true;
                transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.iremboraH[pontoAtual].position, velocidadeDoNPC * Time.deltaTime);
                if (transform.position == GameManager.Instance.iremboraH[pontoAtual].position)
                {
                    pontoAtual++;
                }
                if (pontoAtual >= GameManager.Instance.iremboraH.Length)
                {
                    Destroy(gameObject);
                    comidaNaMesa.transform.position = new Vector3(900f, 900f, 1f);
                    pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;
                    Destroy(comidaNaMesa.gameObject);
                    comidaNaMesa = null;
                    GameManager.Instance.cadeirasOcupadas[numeroCadeira] = false;
                    limiteNPC.Instance.N_atual = limiteNPC.Instance.N_atual - 1;

                    if (historia)
                    {
                        if (gerarNPC.instance.naoSpawn)
                        {
                          
                                gerarNPC.instance.IniciarSpawn();
                                NpcDialogue.Instance.dialogoNumero++;
                                NpcDialogue.Instance.numero = 0;
                                NpcDialogue.Instance.h++;
                                if (NpcDialogue.Instance.h >= 10) { final.instance.FInal = true; }
                        }
                    }
                }
                break;
        }

    }
    public void ReceberComida(int numeroComida)
    {
        if (numeroComida == npedido)
        {
            if (historia)
            {
                if (emanuelImage.gameObject.activeInHierarchy)
                    return;
            }
            audioManager.PlaySFX(audioManager.EntregarPedido);
            Player_movement.instamce.segura = false;
            comidaNaMesa = Player_movement.instamce.comidaAtual.GetComponent<comidafeita>();
            comidaNaMesa.tasegurando = false;
            
            comidaNaMesa.transform.position = GameManager.Instance.posicaoComidaMesa[numeroCadeira].position;
            pratos[numeroCadeira].transform.position = comidaNaMesa.transform.position;

            StartCoroutine(esperar());
            if (npedido == pedidoList[npedido])
            {
                pedidos[npedido].SetActive(false);
                pensamento.SetActive(false);
                sentado = false;
            } 
        }
        else
        {
            Debug.Log("esqueceu o pedido mano");
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
        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.pontosDoCaixa[pontoAtual].position, step); // transform.position = ponto A = minha posi��o ; pontosDoCaixa[pontoAtual].position = ponto atual onde devo ir
        if (transform.position == GameManager.Instance.pontosDoCaixa[pontoAtual].position)// se a nossa posi��o � onde deviamos chegar
        {
            if (pontoAtual != GameManager.Instance.pontosDoCaixa.Length - 1)
            {
                pontoAtual++;
            }
            ultimaPosi��oX = transform.localPosition.x;
        }
    }
    private void EspelharHorizontal()
    {
        if (andando == true & transform.localPosition.x < ultimaPosi��oX)
        {
            animacaoATUAL.SetInteger("andando", 2);
            sp.flipX = false;
        }
        else if (andando == true & transform.localPosition.x > ultimaPosi��oX)
        {
            animacaoATUAL.SetInteger("andando", 2);
            sp.flipX = true;
        }
        else if (sentado == true)      
        {
            animacaoATUAL.SetInteger("andando", 0);
        }
    }
    IEnumerator Esperar()
    {
        wait = 1;
        yield return new WaitForSeconds(0.2f);
        wait = 0;
    }
}
