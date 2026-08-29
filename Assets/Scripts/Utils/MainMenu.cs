using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AntiqueShop.Utils
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private string gameSceneName = "MainScene";

        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button closeSettingsButton;
        [SerializeField] private Button quitButton;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
           
            if (menuPanel != null) menuPanel.SetActive(true);
            if (settingsPanel != null) settingsPanel.SetActive(false);
            if (startButton != null)
                startButton.onClick.AddListener(StartGame);
            if (settingsButton != null)
                settingsButton.onClick.AddListener(OpenSettings);
            if (closeSettingsButton != null)
                closeSettingsButton.onClick.AddListener(CloseSettings);
            if (quitButton != null)
                quitButton.onClick.AddListener(QuitGame);
            
            SyncSliders();
        }

        private void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        private void OpenSettings()
        {
            if (menuPanel != null) menuPanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
            SyncSliders();
        }

        private void CloseSettings()
        {
            if (settingsPanel != null) settingsPanel.SetActive(false);
            if (menuPanel != null) menuPanel.SetActive(true);
        }

        private void SyncSliders()
        {
            if (masterSlider != null) masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
            if (musicSlider != null) musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            if (sfxSlider != null) sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
