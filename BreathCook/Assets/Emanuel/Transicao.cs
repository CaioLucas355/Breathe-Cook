using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letreiro : MonoBehaviour
{
    [Header("LETREIRO")]
    float speed = 10f;
    float textPosBegin = -1366.65f;
    float boundaryTextEnd = 1366.65f;

    public RectTransform myGorectTransform;

    [SerializeField]
    TextMeshProUGUI mainText;

    [SerializeField]
    bool isLooping = false;

    private void Awake()
    {
    }

}
