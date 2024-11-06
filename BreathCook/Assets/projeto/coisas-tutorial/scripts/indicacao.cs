using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicacao : MonoBehaviour
{
    public Vector3 novaPosicao; // A nova posi��o para a qual o objeto ir�
    public float velocidade = 2f; // Velocidade do movimento
    private Vector3 posicaoOriginal; // Posi��o original do objeto
    private bool indoParaNovaPosicao = true; // Controla a dire��o do movimento

    void Start()
    {
        posicaoOriginal = transform.position; // Armazena a posi��o original
    }

    void Update()
    {
        // Determina a posi��o alvo com base na dire��o do movimento
        Vector3 targetPosition = indoParaNovaPosicao ? novaPosicao : posicaoOriginal;

        // Move o objeto em dire��o � posi��o alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidade * Time.deltaTime);

        // Verifica se o objeto chegou � posi��o alvo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            indoParaNovaPosicao = !indoParaNovaPosicao; // Inverte a dire��o
        }
    }
}