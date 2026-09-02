using AntiqueShop.Core;
using AntiqueShop.Items;
using UnityEngine;
using UnityEngine.UI;

namespace AntiqueShop.UI
{
    public class CloseUpView : MonoBehaviour
    {
        [SerializeField] private GameObject visualPanel;
        [SerializeField] private Image image;

        private void Awake() => Hide();

        private void OnEnable() => GameManager.OnRoundChanged += OnItemChanged;

        private void OnDisable() => GameManager.OnRoundChanged -= OnItemChanged;

        private void OnItemChanged(Item item) => Hide();

        public void Toggle(Sprite sprite)
        {
            if (!sprite || (Equals(image.sprite, sprite) && visualPanel.activeSelf))
            {
                Hide();
                return;
            }

            image.sprite = sprite;
            visualPanel.SetActive(true);
        }

        private void Hide()
        {
            if (visualPanel)
            {
                visualPanel.SetActive(false);
            }
        }
    }
}