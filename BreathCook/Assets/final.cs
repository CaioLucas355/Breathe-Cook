using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public static final instance;
    
    public GameObject ele;
    public bool FInal = false;
   public bool FOutal = false;
    public Vector2 target;
    public int Speed12;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed12 * Time.deltaTime;
        if (FInal == true) { transform.position = Vector3.MoveTowards(ele.transform.position, new Vector3(target.x, target.y, 100), step); StartCoroutine(aa3()); }

     
       if (FOutal == true) { SceneManager.LoadScene("01_Menu"); }

    }
    IEnumerator aa3()
    {
        yield return new WaitForSeconds(14);
       FOutal = true;   
        yield return null;
    }
    
}
