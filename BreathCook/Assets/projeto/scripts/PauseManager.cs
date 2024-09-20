using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager: MonoBehaviour
{
    public static PauseManager Instance;

    [SerializeField] private GameObject painelPause;

    public Slider musicSlider;
    private void Awake()
    {
        Instance = this;
        musicSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void Jogar()
    {
        Transition.instance.Transicao(1);
    }
    public void AbrirOptions()
    {
        painelPause.SetActive(true);
    }
    public void FecharOptiones()
    {
        painelPause.SetActive(false);
    }
    public void SairJogo()
    {
        Transition.instance.Transicao(0);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", musicSlider.value);
    }

}