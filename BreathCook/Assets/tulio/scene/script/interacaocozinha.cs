using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacaocozinha : MonoBehaviour
{
    public string destinationtag = "dd";
    Vector3 offset;
    Collider2D collider2D;

    //determinar qual é o ingrediente - agua, camomila, etc
    public int tipoIngrediente;
    public GameObject comidacolocada;

    public Vector3 posicaoinicial;
    void Awake()
   {
        collider2D = GetComponent<Collider2D>();      
   }

    private void Start()
    {
        posicaoinicial = transform.position;
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2D.enabled = false;
        var rayDrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitinfo;
        if (hitinfo = Physics2D.Raycast(rayDrigin, rayDirection))
        {
            if (hitinfo.transform.tag == destinationtag)
            { 
                transform.position = hitinfo.transform.position + new Vector3(0,0,0.01f);

                //chama a checagem da receita no script da receita baseado na posição que largou o ingrediente
                switch (destinationtag)
                {
                    case "bebida":
                        //verificar no script da receita
                        receita.instance.fazerbebida(tipoIngrediente);
                        break;
                }
            }
        
        }
           collider2D.enabled = true;
    }

    Vector3 MouseWorldPosition()
    { 
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    
    }
}
