using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicacao : MonoBehaviour
{
    public Vector3 novaPosicao; // A nova posição para a qual o objeto irá
    public float velocidade = 2f; // Velocidade do movimento
    private Vector3 posicaoOriginal; // Posição original do objeto
    private bool indoParaNovaPosicao = true; // Controla a direção do movimento

    void Start()
    {
        posicaoOriginal = transform.position; // Armazena a posição original
    }

    void Update()
    {
        // Determina a posição alvo com base na direção do movimento
        Vector3 targetPosition = indoParaNovaPosicao ? novaPosicao : posicaoOriginal;

        // Move o objeto em direção à posição alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidade * Time.deltaTime);

        // Verifica se o objeto chegou à posição alvo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            indoParaNovaPosicao = !indoParaNovaPosicao; // Inverte a direção
        }
    }
}