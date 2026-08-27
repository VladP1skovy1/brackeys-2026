using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AntiqueShop
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(RestartGame);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
