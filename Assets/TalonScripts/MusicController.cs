using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip musicClip;

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}

