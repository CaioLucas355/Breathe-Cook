using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacao_cozinha_tutorial : MonoBehaviour
{

    public string destinationtag = "dd";
    Vector3 offset;
    Collider2D collider2DA;
    Rigidbody2D rb;
    bool draging;
    bool foi;
    //determinar qual é o ingrediente - agua, camomila, etc
    public int tipoIngrediente;
    public GameObject comidacolocada;



    public Vector3 posicaoinicial;
    void Awake()
    {
        collider2DA = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        posicaoinicial = transform.position;
        foi = false;

    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        draging = true;


    }

    void OnMouseUp()
    {
        draging = false;



    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        collider2DA.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);


    }
    private void OnTriggerEnter(Collider other)
    {
        foi = true;
    }
    private void OnTriggerExit(Collider other)
    {
        foi = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == destinationtag && !draging)
        {
            foi = true;
            collider2DA.enabled = true;
            transform.position = collision.transform.position;

            switch (destinationtag)
            {

                case "bebida":
                    //verificar no script da receita
                    receita_tutorial.instance.fazerbebida(tipoIngrediente);
                    transform.position = new Vector3(0, 999999999999999999, 0);
                    break;

                case "entrada":
                    //verificar no script da receita
                    receita_tutorial.instance.fazerentrada(tipoIngrediente);
                    transform.position = new Vector3(0, 999999999999999999, 0);
                    break;

                case "sobremesa":
                    //verificar no script da receita
                    receita_tutorial.instance.fazersobremesa(tipoIngrediente);
                    transform.position = new Vector3(0, 999999999999999999, 0);
                    break;
            }
        }
    }
}
