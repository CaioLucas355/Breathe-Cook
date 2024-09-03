using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool[] cadeirasOcupadas;

    public Transform[] pontosDoCaixa;
    public Transform[] pontosCadeiraA;
    public Transform[] pontosCadeiraB;
    public Transform[] pontosCadeiraC;
    public Transform[] pontosCadeiraD;
    public Transform[] pontosCadeiraE;
    public Transform[] pontosCadeiraF;
    public Transform[] pontosCadeiraG;
    public Transform[] pontosCadeiraH;
    public Transform[] pontosCadeiraI;
    public Transform[] pontosCadeiraJ;
    public Transform[] pontosCadeiraK;
    public Transform[] pontosCadeiraL;
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
