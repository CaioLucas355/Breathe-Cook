using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    private AudioSource _audiosource;
    public AudioClip[] songs;
    public float volume;
    private float _trackTimer;
    private float _songsPlayed;
    private bool[] _beenPlayed;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();

        _beenPlayed = new bool[songs.Length];

        if (!_audiosource.isPlaying)
            ChangeSong(Random.Range(0, songs.Length));
    }

    // Update is called once per frame
    void Update()
    {
        _audiosource.volume = volume;

        if (_audiosource.isPlaying)
            _trackTimer += 1 * Time.deltaTime;

        if (!_audiosource.isPlaying || _trackTimer >= _audiosource.clip.length || Input.GetKeyDown(KeyCode.Space))
            ChangeSong(Random.Range(0, songs.Length));

        Reset();
    }

    public void ChangeSong(int songPicked)
    {
        if (!_beenPlayed[songPicked])

        {
            _trackTimer = 0;
            _songsPlayed++;
            _beenPlayed[songPicked] = true;
            _audiosource.clip = songs[songPicked];
            _audiosource.Play();
        }
        else
            _audiosource.Stop();
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
}
