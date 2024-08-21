using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class comidafeita : MonoBehaviour
{
    // CircleCollider2D circleCollider;
    [Header("saber oque seguir")]
    private GameObject playerposicao;

    [Header("mesa posicao / onde deixar ")]
    private GameObject mesaposicao;

    public bool tasegurando = false;

    [Header("movimentacao")]

    public KeyCode botaosegurar = KeyCode.V;
    public KeyCode botaosoutar = KeyCode.B;
    // Start is called before the first frame update
    void Start()
    {
        tasegurando = false;
        playerposicao = GameObject.FindGameObjectWithTag("player");
        mesaposicao = GameObject.FindGameObjectWithTag("mesaposicao");
    }

    // Update is called once per frame
    void Update()
    {
        if (tasegurando == true)
        {
            transform.position = playerposicao.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == null) return;

        if (collision.CompareTag("player"))
        {
            if (tasegurando == false && Input.GetKeyDown(botaosegurar))
            {
                tasegurando = true;
                Debug.Log("tasegurando");


                
            }
        }

        if (collision.CompareTag("pessoaAentregar"))
        {
            if (tasegurando == true && Input.GetKeyDown(botaosoutar))
            {
                Debug.Log("tasoutando");
                transform.position = mesaposicao.transform.position;
                tasegurando = false;
            }
        }
    }
}