using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MusicUIController : MonoBehaviour
{
    [Header("Song Info")]
    [SerializeField] private TextMeshProUGUI songNameText;
    [SerializeField] private TextMeshProUGUI singerNameText;

    [Header("UI Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button randomButton;

    [Header("Music List")]
    [SerializeField] private AudioClip[] tracks;

    [Header("Song Images")]
    [SerializeField] private RawImage songImage;

    public Texture2D songTexture;

    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            Debug.Log("Play Button Clicked!");
            MusicManager.Instance.PlayMusic(tracks);
            UpdatePlayButtonText();
            UpdateSongInfo();
        });

        randomButton.onClick.AddListener(() =>
        {
            Debug.Log("Random Button Clicked!");
            MusicManager.Instance.PlayRandomTrack(tracks);
            UpdateSongInfo();
        });
    }

    private void UpdatePlayButtonText()
    {
        playButton.GetComponentInChildren<TextMeshProUGUI>().text =
            MusicManager.Instance.IsPlaying ? "Stop" : "Play";
    }

    private void UpdateSongInfo()
    {
        string fullName = MusicManager.Instance.CurrentTrack.name;
        songNameText.text = GetSongTitle(fullName);
        singerNameText.text = GetSingerName(fullName);

        // �ark�n�n kapak resmini g�ncelle
        UpdateSongImage(fullName);
    }

    private void UpdateSongImage(string fullName)
    {
        // SongImages klas�r� i�indeki resimler adla e�le�irse �ekilecek
        string imageName = GetSongTitle(fullName);
        Texture2D songTexture = Resources.Load<Texture2D>($"SongImages/{imageName}");

        if (songTexture != null)
        {
            songImage.texture = songTexture;
        }
        else
        {
            Debug.LogWarning($"Image not found for {imageName}"); // Resim yoksa hata logu eklenir
            songImage.texture = null; // Resim yoksa bo� b�rak
        }
    }

    // �ark� ad�n� "-" �ncesinden al�r
    private string GetSongTitle(string fullName)
    {
        if (fullName.Contains(" - "))
        {
            return fullName.Split(new[] { " - " }, System.StringSplitOptions.None)[0];
        }
        return fullName; // E�er ay�r�c� yoksa t�m ismi d�ner
    }

    // �ark�c� ad�n� "-" sonras�ndan al�r
    private string GetSingerName(string fullName)
    {
        if (fullName.Contains(" - "))
        {
            return fullName.Split(new[] { " - " }, System.StringSplitOptions.None)[1];
        }
        return "Unknown Artist"; // E�er ay�r�c� yoksa �ark�c� bilinmiyor
    }
}
