using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReceitaAbrir : MonoBehaviour
{
    AuudioManager audioManager;

    public static ReceitaAbrir Instance;
    [SerializeField] private GameObject painelRC1;
    [SerializeField] private GameObject painelRC2;
    [SerializeField] private GameObject painelRC3;
    [SerializeField] private GameObject image;

    private void Awake()
    {
        Instance = this;
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();
    }
    public void Receita1()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        image.SetActive(false);
        painelRC1.SetActive(true);
        painelRC2.SetActive(false);
        painelRC3.SetActive(false);
    }
    public void Receita2()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        painelRC1.SetActive(false);
        painelRC2.SetActive(true);
        painelRC3.SetActive(false);
    }
    public void Receita3()
    {
        audioManager.PlaySFX(audioManager.Selecionar);
        painelRC1.SetActive(false);
        painelRC2.SetActive(false);
        painelRC3.SetActive(true);
    }
    public void FecharReceitas()
    {
      
        image.SetActive(false);
        painelRC1.SetActive(false);
        painelRC2.SetActive(false);
        painelRC3.SetActive(false);
    }


}
