using AntiqueShop.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AntiqueShop.Utils
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Panels")] [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject letterPanel;
        [SerializeField] private string gameSceneName = "MainScene";

        [Header("Buttons")] [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button closeSettingsButton;
        [SerializeField] private Button quitButton;

        [Header("Audio")] [SerializeField] private AudioClip clickSound;
        [SerializeField] [Range(0f, 1f)] private float clickVolume = 1f;


        private void Start()
        {
            if (menuPanel != null) menuPanel.SetActive(true);
            if (settingsPanel != null) settingsPanel.SetActive(false);

            if (startButton != null)
                startButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    OpenPanel(letterPanel);
                });

            if (nextButton != null)
                nextButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    StartGame();
                });

            if (settingsButton != null)
                settingsButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    OpenPanel(settingsPanel);
                });

            if (closeSettingsButton != null)
                closeSettingsButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    OpenPanel(menuPanel);
                });

            if (quitButton != null)
                quitButton.onClick.AddListener(() =>
                {
                    PlaySoundFX();
                    QuitGame();
                });
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