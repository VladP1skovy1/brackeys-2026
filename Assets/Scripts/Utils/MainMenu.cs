using AntiqueShop.Core;
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
        [SerializeField] private GameObject letterPanel;
        [SerializeField] private string gameSceneName = "MainScene";

        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button closeSettingsButton;
        [SerializeField] private Button quitButton;
        
        [Header("Audio")]
        [SerializeField] private AudioClip clickSound;
        [SerializeField] [Range(0f, 1f)] private float clickVolume = 1f;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            if (menuPanel != null) menuPanel.SetActive(true);
            if (settingsPanel != null) settingsPanel.SetActive(false);

            if (startButton != null)
                startButton.onClick.AddListener(() => { PlaySoundFX(); OpenPanel(letterPanel); });
            
            if (nextButton != null)
                nextButton.onClick.AddListener(() => { PlaySoundFX(); StartGame(); });

            if (settingsButton != null)
                settingsButton.onClick.AddListener(() => { PlaySoundFX(); OpenPanel(settingsPanel); });

            if (closeSettingsButton != null)
                closeSettingsButton.onClick.AddListener(() => { PlaySoundFX(); OpenPanel(menuPanel); });

            if (quitButton != null)
                quitButton.onClick.AddListener(() => { PlaySoundFX(); QuitGame(); });
            
            SetupSliders();

        }
        
        private void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }
        
        private void OpenPanel(GameObject targetPanel)
        {
            if (menuPanel) menuPanel.SetActive(menuPanel == targetPanel);
            if (settingsPanel) settingsPanel.SetActive(settingsPanel == targetPanel);
            if (letterPanel) letterPanel.SetActive(letterPanel == targetPanel);
        }

        private void SetupSliders()
        {
            SetupSlider(masterSlider, "MasterVolume", (v) => SoundMixerManager.Instance?.SetMasterVolume(v));
            SetupSlider(musicSlider, "MusicVolume", (v) => SoundMixerManager.Instance?.SetMusicVolume(v));
            SetupSlider(sfxSlider, "SoundFXVolume", (v) => SoundMixerManager.Instance?.SetSoundFXVolume(v));
        }
        
        private void SetupSlider(Slider slider, string prefName, System.Action<float> onValueChangedAction)
        {
            if (slider == null) return;

            float savedValue = PlayerPrefs.GetFloat(prefName, 1f);
            slider.value = savedValue;
            onValueChangedAction?.Invoke(savedValue);

            slider.onValueChanged.AddListener((value) =>
            {
                onValueChangedAction?.Invoke(value);
                PlayerPrefs.SetFloat(prefName, value);
                PlayerPrefs.Save();
            });
        }
        
        private void PlaySoundFX()
        {
            if (SoundFXManager.Instance != null && clickSound != null)
            {
                SoundFXManager.Instance.PlaySoundFXClip(clickSound, transform, clickVolume);
            }
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
