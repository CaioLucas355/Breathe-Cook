using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class comidafeita : MonoBehaviour
{
    // CircleCollider2D circleCollider;
    [Header("comida:")]
    public int comida;

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
            
            if (tasegurando == false && Input.GetKey(botaosegurar) )
            {
                tasegurando = true;
                



            }
        }


        if (collision.CompareTag("pessoaAentregar"))
        {
            if (tasegurando == true && Input.GetKey(botaosoutar) )
            {
               
                transform.position = mesaposicao.transform.position;
                tasegurando = false;
                gameObject.tag = "comidacomcliente";
              
            }
        }

    }

       

       
    
}
