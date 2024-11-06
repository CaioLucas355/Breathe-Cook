using UnityEngine;

public class ScalePulse : MonoBehaviour
{
    public float scaleMultiplier = 1.5f; // Fator de aumento da escala
    public float duration = 1.0f; // Duração de um ciclo (aumento + diminuição)

    private Vector3 originalScale;
    private float timer;

    void Start()
    {
        originalScale = transform.localScale; // Salva a escala original
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Calcula a fração do ciclo atual (0 a 1)
        float t = Mathf.PingPong(timer / duration, 1.0f);

        // Interpola entre a escala original e a escala aumentada
        float scale = Mathf.Lerp(1.0f, scaleMultiplier, t);

        transform.localScale = originalScale * scale;
    }
}