using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limiteNPC : MonoBehaviour
{
    public static limiteNPC Instance;

    public int N_atual;
    public  int contador;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
        N_atual = 1;
    }

    // Update is called once per frame
    void Update()
    {
        contador = N_atual;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pessoaAentregar"))
        {
            N_atual++;

        }
        

    }
}
