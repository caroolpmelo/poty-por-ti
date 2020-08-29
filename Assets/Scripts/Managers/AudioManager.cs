using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgMusic;
    [SerializeField]
    private AudioClip ambience;

    [SerializeField]
    private List<AudioClip> sounds = new List<AudioClip>(4);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //if (bgMusic)
        //    AudioSource.PlayClipAtPoint(bgMusic, Camera.main.transform.position);
        //if (ambience)
        //    AudioSource.PlayClipAtPoint(ambience, Camera.main.transform.position);
    }

    public AudioClip GetRandomSound()
    {
        return sounds[Random.Range(0, 4)];
    }

    public static AudioManager Instance { get; private set; }
}
