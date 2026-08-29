using AntiqueShop.Core;
using AntiqueShop.Items;
using TMPro;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ToolReadout : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;

        private void Awake() => Hide();

        private void OnEnable() => GameManager.OnRoundChanged += OnItemChanged;

        private void OnDisable() => GameManager.OnRoundChanged -= OnItemChanged;

        private void OnItemChanged(Item item) => Hide();

        public void Show(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Hide();
                return;
            }

            label.text = text;
            label.enabled = true;
        }

        public void Hide() => label.enabled = false;
    }
}
