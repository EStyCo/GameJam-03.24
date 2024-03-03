using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private int score = 0;
    private AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips;
    private float currentClipDuration;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public static void DeleteSingletonInstance()
    {
        if (Instance)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayMusic();
    }

    public void PlayMusic()
    {
        audioSource.clip = audioClips[Random.Range(0, 2)];
        currentClipDuration = audioSource.clip.length;

        audioSource.Play();
        StartCoroutine(DelayMusic());
    }

    IEnumerator DelayMusic()
    {
        yield return new WaitForSeconds(currentClipDuration);
        NextSong();
    }

    public void NextSong()
    {
        StopAllCoroutines();

        audioSource.Stop();

        PlayMusic();
    }

    public void OnDuhast()
    {
        StopAllCoroutines();
        audioSource.Stop();

        audioSource.volume = 1f;

        audioSource.clip = audioClips[2];
        currentClipDuration = audioSource.clip.length;

        audioSource.Play();
    }

    public void AddScore()
    {
        score++;
        GameObject[] a = GameObject.FindGameObjectsWithTag("Score");
        a.First().GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}

