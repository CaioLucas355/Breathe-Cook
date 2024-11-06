using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI2 : MonoBehaviour
{
    public Image background1;
    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI talkText1;

    public float speed = 10f;
    bool open = false;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            background1.fillAmount = Mathf.Lerp(background1.fillAmount, 1, speed * Time.deltaTime);
        }
        else
        {
            background1.fillAmount = Mathf.Lerp(background1.fillAmount, 0, speed * Time.deltaTime);
        }
    }
    public void SetName(string name)
    {
        nameText1.text = name;
    }
    public void Enable()
    {
        background1.fillAmount = 0;
        open = true;
    }
    public void Disable()
    {
        open = false;
        nameText1.text = "";
        talkText1.text = "";
    }


}
