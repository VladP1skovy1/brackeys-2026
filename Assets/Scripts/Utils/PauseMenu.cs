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

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);

            if (resumeButton != null)
                resumeButton.onClick.AddListener(Resume);

            if (openSettingsButton != null)
                openSettingsButton.onClick.AddListener(OpenSettings);

            if (closeSettingsButton != null)
                closeSettingsButton.onClick.AddListener(CloseSettings);

            if (mainMenuButton != null)
                mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void Update()
        {
            if (UnityEngine.InputSystem.Keyboard.current != null && 
                UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                HandleEscapeKey();
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
                
                SyncSliders();
            }
        }

        public void OpenSettings()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
            SyncSliders();
        }

        public void CloseSettings()
        {
            if (settingsPanel) settingsPanel.SetActive(false);
            if (pausePanel) pausePanel.SetActive(true);
        }

        private void SyncSliders()
        {
            if (masterSlider != null) masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
            if (musicSlider != null) musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            if (sfxSlider != null) sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        }

        public void Resume()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}