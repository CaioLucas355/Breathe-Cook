using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GerenciadordeMusica : MonoBehaviour
{
    private static GerenciadordeMusica _instance;
    public static GerenciadordeMusica Instance
    {
        get
        {
            return _instance;
        }
    }
    [Header("GERENCIADOR DE MUSICA")]
    private AudioSource _audiosource;
    public AudioClip[] songs;
    public float volume;
    private float _trackTimer;
    private float _songsPlayed;
    private bool[] _beenPlayed;

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
        _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();

        _beenPlayed = new bool[songs.Length];

        if (!_audiosource.isPlaying)
            ChangeSongRandom(Random.Range(0, songs.Length));

        StartCoroutine(AutoScrollText());

    }

    // Update is called once per frame
    void Update()
    {
        _audiosource.volume = PlayerPrefs.GetFloat("Volume");

        if (_audiosource.isPlaying)
            _trackTimer += 1 * Time.deltaTime;

        if (!_audiosource.isPlaying || _trackTimer >= _audiosource.clip.length || Input.GetKeyDown(KeyCode.Space))
            ChangeSongRandom(Random.Range(0, songs.Length));

        Reset();
    }

    public void ChangeSongRandom(int songPicked)
    {
        if (!_beenPlayed[songPicked])

        {
            _trackTimer = 0;
            _songsPlayed++;
            _beenPlayed[songPicked] = true;
            _audiosource.clip = songs[songPicked];
            _audiosource.Play();
            mainText.text = _audiosource.clip.name;
        }
        else
            _audiosource.Stop();
    }
    public void ChangeSong(int songPicked)
    {
        _trackTimer = 0;
        _songsPlayed++;
        _beenPlayed[songPicked] = true;
        _audiosource.clip = songs[songPicked];
        _audiosource.Play();
        mainText.text = _audiosource.clip.name;
    }

    private void Reset()
    {
        if (_songsPlayed == songs.Length)
        {
            _songsPlayed = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                if (i == songs.Length)
                    break;
                else
                    _beenPlayed[i] = false;
            }
        }
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
                    myGorectTransform.localPosition = new Vector3(textPosBegin, myGorectTransform.localPosition.y, myGorectTransform.localPosition.z);
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
