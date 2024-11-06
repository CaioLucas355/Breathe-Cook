using System.Collections;
using UnityEngine;

public class gerarNPC : MonoBehaviour
{
    public static gerarNPC instance; // Corrigido para "instance"

    [Header("Objeto que será instanciado")]
    public GameObject NPC;

    [Header("Local de Spawn")]
    public GameObject localspawn;

    int maximodeNPCs;
    int freq1 = 14;
    int freq2 = 20;
    public int npcsDialogo;

    [Header("Porta")]
    public GameObject porta;
    Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (NPC == null || localspawn == null || porta == null)
        {
            Debug.LogError("Certifique-se de que NPC, localspawn e porta estão atribuídos no Inspector.");
            return;
        }

        animator = porta.GetComponent<Animator>();
        StartCoroutine(spawn());
    }

    private void FixedUpdate()
    {
        if (word.instamce   .dia == 0) maximodeNPCs = 5;
        else if (word.instamce.dia == 1) { maximodeNPCs = 6; freq1 = 10; freq2 = 15; }
        else if (word.instamce.dia == 2) { maximodeNPCs = 7; freq1 = 7; freq2 = 12; }
        else if (word.instamce.dia == 3) { maximodeNPCs = 7; freq1 = 5; freq2 = 9; }
        else if (word.instamce.dia == 4) { maximodeNPCs = 8; freq1 = 4; freq2 = 7; }
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(1);

        if (word.instamce.ta_de_noite == false)
        {
            if (limiteNPC.Instance.contador >= maximodeNPCs)
            {
                Debug.Log("Aguardando: Limite de NPCs atingido");
                yield return new WaitForSeconds(4);
            }
            else
            {
                int frequencia = Random.Range(freq1, freq2);
                yield return new WaitForSeconds(frequencia);

                if (NPC != null && localspawn != null)
                {
                    Debug.Log("Instanciando NPC...");
                    Instantiate(NPC, localspawn.transform.position, Quaternion.identity);
                    npcsDialogo++;

                    animator.SetInteger("abre", 1);
                    yield return new WaitForSeconds(1.5f);
                    animator.SetInteger("abre", 0);
                }
                else
                {
                    Debug.LogError("NPC ou localspawn não foram atribuídos!");
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(2);
        }

        // Continua chamando o método para respawn de NPCs enquanto o jogo roda
        StartCoroutine(spawn());
    }
}
