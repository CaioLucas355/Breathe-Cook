using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class interacao2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject origem;
    public GameObject vaipara;
   
    Collider2D collider2D;

    
    

    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
  //      transform.position = new Vector3(vaipara);
    }
}
