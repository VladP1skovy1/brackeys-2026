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
            if (sprite == null || (view.sprite == sprite && view.color.a > 0))
            {
                Hide();
                return;
            }

            view.sprite = sprite;
            Color c = view.color;
            c.a = 1f;
            view.color = c;
        }

        private void Hide()
        {
            Color c = view.color;
            c.a = 0f;
            view.color = c;
        }
    }
}