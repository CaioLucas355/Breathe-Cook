using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class interacaocozinha : MonoBehaviour
{
    
    public string destinationtag = "dd";
    Vector3 offset;
    Collider2D collider2D;
    Rigidbody2D rb;
    bool draging;
    bool foi;
    //determinar qual é o ingrediente - agua, camomila, etc
    public int tipoIngrediente;
    public GameObject comidacolocada;

    TrailRenderer tril;

    public Vector3 posicaoinicial;
    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        posicaoinicial = transform.position;
        foi = false;
        tril = GetComponent<TrailRenderer>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        draging = true;
        tril.enabled = true;
        
    }

    void OnMouseUp()
    {
        draging = false;
        tril.enabled = false;

       // if (foi == false) 
     //   {
        //    transform.position = posicaoinicial;
      //  }
        
        /*  var rayDrigin = Camera.main.transform.position;
          var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
          RaycastHit2D hitinfo;
          if (hitinfo = Physics2D.Raycast(rayDrigin, rayDirection))
          {
              if (hitinfo.transform.tag == destinationtag)
              { 
                  transform.position = hitinfo.transform.position;
                  collider2D.enabled = false;
                  rb.bodyType = RigidbodyType2D.Kinematic;
                  //chama a checagem da receita no script da receita baseado na posição que largou o ingrediente
                  switch (destinationtag)
                  {
                      case "bebida":
                          //verificar no script da receita
                          receita.instance.fazerbebida(tipoIngrediente);
                          break;

                      case "entrada":
                          //verificar no script da receita
                          receita.instance.fazerentrada(tipoIngrediente);
                          break;

                      case "sobremesa":
                          //verificar no script da receita
                          receita.instance.fazersobremesa(tipoIngrediente);
                          break;
                  }
              }
              else
              {
                  Debug.Log(hitinfo.transform.tag);
                  transform.position = posicaoinicial;
              }

          }
             collider2D.enabled = true;
          rb.bodyType = RigidbodyType2D.Dynamic;
        */
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        collider2D.enabled = true;
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
            collider2D.enabled = true;
            transform.position = collision.transform.position;
            
            switch (destinationtag)
            {

                case "bebida":
                    //verificar no script da receita
                    receita.instance.fazerbebida(tipoIngrediente);
                    transform.position = new Vector3(0,999999999999999999,0);
                    break;

                case "entrada":
                    //verificar no script da receita
                    receita.instance.fazerentrada(tipoIngrediente);
                    transform.position = new Vector3(0, 999999999999999999, 0);
                    break;

                case "sobremesa":
                    //verificar no script da receita
                    receita.instance.fazersobremesa(tipoIngrediente);
                    transform.position = new Vector3(0, 999999999999999999, 0);
                    break;
            }
        }
    }
}
