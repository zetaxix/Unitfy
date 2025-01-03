using UnityEngine;
using UnityEngine.UI;

public class MusicUIController : MonoBehaviour
{
    [Header("Song Info")]
    [SerializeField] private Text songNameText;
    [SerializeField] private Text singerNameText;

    [Header("UI Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button randomButton;

    [Header("Music List")]
    [SerializeField] private AudioClip[] tracks;

    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlayMusic();
            UpdatePlayButtonText();
        });

        randomButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlayRandomTrack(tracks);
            UpdateSongInfo();
        });
    }

    private void UpdatePlayButtonText()
    {
        playButton.GetComponentInChildren<Text>().text =
            MusicManager.Instance.IsPlaying ? "Stop" : "Play";
    }

    private void UpdateSongInfo()
    {
        string fullName = MusicManager.Instance.CurrentTrack.name;
        songNameText.text = GetSongTitle(fullName);
        singerNameText.text = GetSingerName(fullName);
    }

    // Þarký adýný "-" öncesinden alýr
    private string GetSongTitle(string fullName)
    {
        if (fullName.Contains(" - "))
        {
            return fullName.Split(new[] { " - " }, System.StringSplitOptions.None)[0];
        }
        return fullName; // Eðer ayýrýcý yoksa tüm ismi döner
    }

    // Þarkýcý adýný "-" sonrasýndan alýr
    private string GetSingerName(string fullName)
    {
        if (fullName.Contains(" - "))
        {
            return fullName.Split(new[] { " - " }, System.StringSplitOptions.None)[1];
        }
        return "Unknown Artist"; // Eðer ayýrýcý yoksa þarkýcý bilinmiyor
    }

}
