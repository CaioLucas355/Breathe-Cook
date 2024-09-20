using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool[] cadeirasOcupadas;
    int numeros = 8;

    [Header("ir para as Cadeiras")]
    public Transform[] pontosDoCaixa;
    public Transform[] pontosCadeiraA;
    public Transform[] pontosCadeiraB;
    public Transform[] pontosCadeiraC;
    public Transform[] pontosCadeiraD;
    public Transform[] pontosCadeiraE;
    public Transform[] pontosCadeiraF;
    public Transform[] pontosCadeiraG;
    public Transform[] pontosCadeiraH;

    [Header("ir para casa")]
    public Transform[] iremboraA;
    public Transform[] iremboraB;
    public Transform[] iremboraC;
    public Transform[] iremboraD;
    public Transform[] iremboraE;
    public Transform[] iremboraF;
    public Transform[] iremboraG;
    public Transform[] iremboraH;

    [Header("posicao das comidas nas mesas")]
    public Transform[] posicaoComidaMesa;
   

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
