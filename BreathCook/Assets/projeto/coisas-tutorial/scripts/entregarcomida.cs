using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entregarcomida : MonoBehaviour
{
    public GameObject salmao;
    public GameObject pao;
    public GameObject manga;
    public GameObject abacate;
    public GameObject folha;

    private Vector3 salmaoLOC;
    private Vector3 paoLOC;
    private Vector3 mangaLOC;


    private void Start()
    {
      salmaoLOC = salmao.transform.position;
      paoLOC = pao.transform.position;
      mangaLOC = manga.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            if (PLAYER_Tutorial.instamce.segura == true)
            {
                NPC_tutorial.Instance.npedido = 4;
                NPC_tutorial.Instance.pedido6.SetActive(false);
                NPC_tutorial.Instance.pedido5.SetActive(true);
                salmao.SetActive(true);
                pao.SetActive(true);
                manga.SetActive(true);
                abacate.SetActive(false);
                folha.SetActive(false);
                salmao.transform.position = salmaoLOC;
                pao.transform.position = paoLOC;
                manga.transform.position = mangaLOC;
                this.enabled = false;
            }
        }
    }

}
