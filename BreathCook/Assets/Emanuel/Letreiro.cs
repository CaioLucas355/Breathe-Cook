using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letreiro : MonoBehaviour
{
    float speed = 10f;
    float textPosBegin = -1366.65f;
    float boundaryTextEnd = 1366.65f;

    RectTransform myGorectTransform;

    [SerializeField]
    TextMeshProUGUI mainText;

    [SerializeField]
    bool isLooping = false;
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.x < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.right * speed * Time.deltaTime);
            if (myGorectTransform.localPosition.x > boundaryTextEnd)
            {
                if (isLooping)
                {
                    myGorectTransform.localPosition = new Vector3(textPosBegin, myGorectTransform.localPosition.y, myGorectTransform.localPosition.z); ;
                }
                else
                {
                    break;
                }
            }
            yield return null;
        }
    }
}
