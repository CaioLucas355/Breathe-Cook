using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOptiones;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }   

    public void AbrirOptions()
    {
        painelMenuInicial.SetActive(false);
        painelOptiones.SetActive(true);
    }
    public void FecharOptiones()
    {
        painelOptiones.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
