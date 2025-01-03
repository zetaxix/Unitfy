using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance => _instance;

    private AudioSource audioSource;

    // Þu an çalmakta olan müziðin bilgisi
    public AudioClip CurrentTrack => audioSource.clip;

    // Müzik oynatýlýyor mu kontrolü
    public bool IsPlaying => audioSource.isPlaying;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayRandomTrack(AudioClip[] tracks)
    {
        AudioClip randomTrack = tracks[Random.Range(0, tracks.Length)];
        audioSource.clip = randomTrack;
        audioSource.Play();
    }
}
