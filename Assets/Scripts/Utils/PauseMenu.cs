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
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button backToPauseMenuButton;
        [SerializeField] private Button mainMenuButton;

        [Header("Audio")] 
        [SerializeField] private AudioClip clickSound;
        [SerializeField] [Range(0f, 1f)] private float clickVolume;


        private void Start()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);

            if (resumeButton != null)
                resumeButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    Resume();
                });

            if (settingsButton != null)
                settingsButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    OpenSettings();
                });

            if (backToPauseMenuButton != null)
                backToPauseMenuButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    CloseSettings();
                });

            if (mainMenuButton != null)
                mainMenuButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    GoToMainMenu();
                });
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
            pausePanel.SetActive(!isOpen);
            if (settingsPanel) settingsPanel.SetActive(false);
        }

        private void OpenSettings()
        {
            if (pausePanel != null) pausePanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
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
    }
}