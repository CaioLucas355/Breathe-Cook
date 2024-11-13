using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager: MonoBehaviour
{

    AuudioManager audioManager;

    public static PauseManager Instance;

    [SerializeField] private GameObject painelPause;

    public Slider musicSlider;
    private void Awake()
    {
        Instance = this;
        musicSlider.value = PlayerPrefs.GetFloat("Volume");
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();
    }
    public void Jogar()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        Transition.instance.Transicao(1);
    }
    public void AbrirOptions()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        painelPause.SetActive(true);
    }
    public void FecharOptiones()
    {
        audioManager.PlaySFX(audioManager.Sair);
        painelPause.SetActive(false);
    }
    public void SairJogo()
    {
        audioManager.PlaySFX(audioManager.Sair);
        Transition.instance.Transicao(0);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", musicSlider.value);
    }

}