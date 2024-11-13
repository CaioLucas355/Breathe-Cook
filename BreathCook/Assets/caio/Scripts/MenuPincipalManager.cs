using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPincipalManager : MonoBehaviour
{
    AuudioManager audioManager; 
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
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();

        Instance = this;
        musicSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void Jogar()
    {
        audioManager.PlaySFX(audioManager.EntregarPedido);
        enfeites.SetActive(false);
        Transition.instance.Transicao(1);   
    }
    public void AbrirOptions()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        painelMenuInicial.SetActive(false);
        painelOptiones.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(false);
    }
    public void FecharOptiones()
    {
        audioManager.PlaySFX(audioManager.Sair);
        painelOptiones.SetActive(false);
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(true);
    }
    
    public void CreditosGame()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        painelCreditos.SetActive(true);
        painelMenuInicial.SetActive(false);
        painelOptiones.SetActive(false);
        enfeites.SetActive(false);
    }
    public void FecharCreditos()
    {
        audioManager.PlaySFX(audioManager.Sair);
        painelOptiones.SetActive(false);
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        enfeites.SetActive(true);
    }
    public void SairJogo()
    {
        audioManager.PlaySFX(audioManager.Sair);
        enfeites.SetActive(false);
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
    public void AbrirTutorial()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        enfeites.SetActive(false);
        Debug.Log("Ir pro Tutorial");

        Transition.instance.Transicao(2);

    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", musicSlider.value);
    }

}
