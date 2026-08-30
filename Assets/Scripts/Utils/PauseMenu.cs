using AntiqueShop.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AntiqueShop.Utils
{
    public class PauseMenu : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private string mainMenuSceneName = "MainMenu";
        
        [Header("Buttons")]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button openSettingsButton;
        [SerializeField] private Button closeSettingsButton;
        [SerializeField] private Button mainMenuButton;
        
        [Header("Audio")]
        [SerializeField] private AudioClip clickSound;
        [SerializeField] [Range(0f, 1f)] private float clickVolume;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);

            if (resumeButton != null)
                resumeButton.onClick.AddListener(() => { PlaySoundFX(); Resume(); });

            if (openSettingsButton != null)
                openSettingsButton.onClick.AddListener(() => { PlaySoundFX(); OpenSettings(); });

            if (closeSettingsButton != null)
                closeSettingsButton.onClick.AddListener(() => { PlaySoundFX(); CloseSettings(); });

            if (mainMenuButton != null)
                mainMenuButton.onClick.AddListener(() => { PlaySoundFX(); GoToMainMenu(); });
            
            SetupSliders();
        }

        

        private void Update()
        {
            if (UnityEngine.InputSystem.Keyboard.current != null && 
                UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                HandleEscapeKey();
            }
        }
        
        
        private void PlaySoundFX()
        {
            if (SoundFXManager.Instance != null && clickSound != null)
            {
                SoundFXManager.Instance.PlaySoundFXClip(clickSound, transform, clickVolume);
            }
        }

        private void HandleEscapeKey()
        {
            if (settingsPanel && settingsPanel.activeSelf)
            {
                CloseSettings();
                return;
            }
            TogglePauseMenu();
        }

        private void TogglePauseMenu()
        {
            if (!pausePanel) return;

            bool isOpen = pausePanel.activeSelf;
            
            if (isOpen)
            {
                pausePanel.SetActive(false);
                if (settingsPanel) settingsPanel.SetActive(false);
            }
            else
            {
                pausePanel.SetActive(true);
                if (settingsPanel) settingsPanel.SetActive(false);
                
                SetupSliders();
            }
        }

        private void OpenSettings()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
            SetupSliders();
        }

        private void CloseSettings()
        {
            if (settingsPanel) settingsPanel.SetActive(false);
            if (pausePanel) pausePanel.SetActive(true);
        }

        private void Resume()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);
        }

        private void GoToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        
        
        private void SetupSliders()
        {
            SetupSlider(masterSlider, "MasterVolume", (v) => SoundMixerManager.Instance?.SetMasterVolume(v));
            SetupSlider(musicSlider, "MusicVolume", (v) => SoundMixerManager.Instance?.SetMusicVolume(v));
            SetupSlider(sfxSlider, "SoundFXVolume", (v) => SoundMixerManager.Instance?.SetSoundFXVolume(v));
        }

        private void SetupSlider(Slider slider, string prefName, System.Action<float> onValueChangedAction)
        {
            if (!slider) return;

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
    }
}