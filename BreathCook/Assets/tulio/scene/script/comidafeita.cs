using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comidafeita : MonoBehaviour
{

    public static comidafeita Instance;

    // CircleCollider2D circleCollider;
    [Header("comida:")]
    public int comida;

    [Header("saber oque seguir")]
    private GameObject playerposicao;

    [Header("mesa posicao / onde deixar ")]
    public GameObject mesaposicao;

    public bool tasegurando = false;

    [Header("movimentacao")]

    public KeyCode botaosegurar = KeyCode.V;
    public KeyCode botaosoutar = KeyCode.B;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        tasegurando = false;
        playerposicao = GameObject.FindGameObjectWithTag("player");
        
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
                Player_movement.instamce.segura = true;
                Player_movement.instamce.comidaAtual = gameObject;
            }
        }

      //  if (collision.CompareTag("excluir"))
       // {
        //    tasegurando = false;
         //   Player_movement.instamce.segura = fa;
          //  Destroy(gameObject);
        //}
    }

       

       
    
}
