using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerarNPC : MonoBehaviour
{



    [Header("oque vai spawnar")]
    public GameObject NPC;

    [Header("local de spawn")]
    public GameObject localspawn;





    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(spawn());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }



    IEnumerator spawn()
    {
        yield return new WaitForSeconds(1);
        if (limiteNPC.Instance.contador >= 8)
        {
            Debug.Log("esperando1");
            yield return new WaitForSeconds(4);
            StartCoroutine(spawn());
        }
        else
        {
            int frequencia = Random.Range(2, 3);
            yield return new WaitForSeconds(frequencia);
            Instantiate(NPC, localspawn.transform);
            StartCoroutine(spawn());
        }

    }
}
