using System.Collections;
using UnityEngine;

public class gerarNPC : MonoBehaviour
{
    public static gerarNPC instance; // Corrigido para "instance"

    AuudioManager audioManager;

    [Header("Objeto que será instanciado")]
    public GameObject NPC;

    [Header("Local de Spawn")]
    public GameObject localspawn;

    int maximodeNPCs;
    int freq1 = 1; //ERA 14
    int freq2 = 5;//ERA 20
    public int npcsDialogo;

    [Header("Porta")]
    public GameObject porta;
    Animator animator;

    public int npcsSpawnados;
    public int npcHistoria = 0;

    public bool naoSpawn;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<AuudioManager>();

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
        if (word.instamce.dia == 0) maximodeNPCs = 8;
       
    }
    public void IniciarSpawn()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        Debug.Log("fjsbhgugiyfsduiyfghbsduif");
        yield return new WaitForSeconds(1);
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
                GameObject go = Instantiate(NPC, localspawn.transform.position, Quaternion.identity);
                if (npcsSpawnados == 0 || npcsSpawnados == 3 || npcsSpawnados == 6 || npcsSpawnados == 9 || npcsSpawnados == 12)
                {
                    go.GetComponentInChildren<MovmentNPC>().historia = true;
                    npcsSpawnados++;

                    animator.SetInteger("abre", 1);
                    audioManager.PlaySFX(audioManager.AbrirPorta);
                    yield return new WaitForSeconds(1.5f);
                    animator.SetInteger("abre", 0);
                    audioManager.PlaySFX(audioManager.FecharPorta);
                    naoSpawn = true;
                    StopAllCoroutines();
                }
                else
                {
                    npcsSpawnados++;
                    animator.SetInteger("abre", 1);
                    audioManager.PlaySFX(audioManager.AbrirPorta);
                    yield return new WaitForSeconds(1.5f);
                    animator.SetInteger("abre", 0);
                    audioManager.PlaySFX(audioManager.FecharPorta);
                    StartCoroutine(spawn());
                }
            }
        }
    }
}
