using AntiqueShop.Core;
using AntiqueShop.Items;
using UnityEngine;
using UnityEngine.UI;

namespace AntiqueShop.UI
{
    public class CloseUpView : MonoBehaviour
    {
        [SerializeField] private Image view;

        private void Awake() => Hide();

        private void OnEnable() => GameManager.OnRoundChanged += OnItemChanged;

        private void OnDisable() => GameManager.OnRoundChanged -= OnItemChanged;

        private void OnItemChanged(Item item) => Hide();

        public void Toggle(Sprite sprite)
        {
            if (sprite == null || (view.sprite == sprite && view.enabled))
            {
                Hide();
                return;
            }

            view.sprite = sprite;
            view.enabled = true;
        }

        public void Hide() => view.enabled = false;
    }
}
