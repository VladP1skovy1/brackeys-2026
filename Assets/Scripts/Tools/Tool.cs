using AntiqueShop.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AntiqueShop.Tools
{
    public abstract class Tool : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CurrentItem itemHolder;

        protected Item CurrentItem { get; private set; }

        private void OnEnable()
        {
            CurrentItem = itemHolder.Value;
            itemHolder.Changed += OnItemChanged;
        }

        private void OnDisable() => itemHolder.Changed -= OnItemChanged;

        private void OnItemChanged(Item item) => CurrentItem = item;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnToolClick();
            }
        }

        protected abstract void OnToolClick();

        public abstract object Read();
    }
}
