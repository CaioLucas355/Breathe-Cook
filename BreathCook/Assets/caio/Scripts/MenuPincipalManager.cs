using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPincipalManager : MonoBehaviour
{
    public static MenuPincipalManager Instance;
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private Scene Tutorial;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOptiones;
    [SerializeField] private GameObject painelCreditos;
    [SerializeField] private GameObject enfeites;

    public Slider musicSlider;
    private void Awake()
    {
        Instance = this;
        musicSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void Jogar()
    {
        enfeites.SetActive(false);
        Transition.instance.Transicao(1);   
    }
    public void AbrirOptions()
    {   
        painelMenuInicial.SetActive(false);
        painelOptiones.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(false);
    }
    public void FecharOptiones()
    {
        painelOptiones.SetActive(false);
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(true);
    }
    
    public void CreditosGame()
    {
        painelCreditos.SetActive(true);
        painelMenuInicial.SetActive(false);
        painelOptiones.SetActive(false);
        enfeites.SetActive(false);
    }
    public void FecharCreditos()
    {
        painelOptiones.SetActive(false);
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(true);
    }
    public void SairJogo()
    {
        enfeites.SetActive(false);
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    public void AbrirTutorial()
    {
        enfeites.SetActive(false);
        Debug.Log("Ir pro Tutorial");

        Transition.instance.Transicao(2);

    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", musicSlider.value);
    }

}
