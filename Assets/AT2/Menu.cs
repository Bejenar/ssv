using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master_volume";
    private const string SOUND_VOLUME_KEY = "sound_volume";


    private AudioSource _audioSource;
    
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private TextMeshProUGUI scoreLabel;

    private int score;
    
    private bool toggle;

    public static float MasterVolume
    {
        get => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        set => PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Mathf.Clamp(value, 0f, 1f));
    }
    
    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat(SOUND_VOLUME_KEY);
        set => PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, Mathf.Clamp(value, 0f, 1f));
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        volumeSlider.value = MasterVolume;
        soundSlider.value = SoundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVolume(volumeSlider.value);
        ChangeSoundVolume(soundSlider.value);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(!toggle);
        }
        
    }

    public void TogglePause(bool pause)
    {
        toggle = pause;
        Time.timeScale = pause ? 0 : 1;
        menuPanel.SetActive(pause);
    }

    public void ChangeVolume(float volumeSliderValue)
    {
        MasterVolume = volumeSliderValue;
        _audioSource.volume = volumeSliderValue;
    }
    
    public void ChangeSoundVolume(float volumeSliderValue)
    {
        SoundVolume = volumeSliderValue;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreLabel.text = this.score.ToString();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}