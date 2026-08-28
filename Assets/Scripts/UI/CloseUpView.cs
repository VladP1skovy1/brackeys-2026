using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class CloseUpView : MonoBehaviour
    {
        [SerializeField] private CurrentItem itemHolder;
        [SerializeField] private SpriteRenderer view;

        private void OnEnable() => itemHolder.Changed += OnItemChanged;

        private void OnDisable() => itemHolder.Changed -= OnItemChanged;

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
