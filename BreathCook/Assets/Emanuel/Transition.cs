using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static Transition instance;
    public GameObject panelOut;

    private void Awake()
    {
        instance = this;
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Transicao(int cena)
    {
        StartCoroutine(IniciarTransicao(cena));
    }

    IEnumerator IniciarTransicao(int cena)
    {
        panelOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(cena);
    }

}
