using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuudioManager : MonoBehaviour
{
 
    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio clip--------")]
    public AudioClip Sair;
    public AudioClip PedidoPronto;
    public AudioClip AbrirPorta;
    public AudioClip FecharPorta;
    public AudioClip EntregarPedido;
    public AudioClip FazendoPedido;
    public AudioClip Selecionar;
    public AudioClip oi;

    
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.Stop();
        SFXSource.clip = clip;
        SFXSource.Play();
    }
    
}
