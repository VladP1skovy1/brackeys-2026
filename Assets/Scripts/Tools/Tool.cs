using AntiqueShop.Core;
using AntiqueShop.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AntiqueShop.Tools
{
    public abstract class Tool : MonoBehaviour, IPointerClickHandler
    {
        protected Item CurrentItem { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnToolClick();
            }
        }

        protected abstract void OnToolClick();

        public abstract object Read();
        
        private void UpdateItem(Item item)
        {
            CurrentItem = item;
        }
        
        private void OnEnable()
        {
            GameManager.OnRoundChanged += UpdateItem;
        }
        
        private void OnDisable()
        {
            GameManager.OnRoundChanged -= UpdateItem;
        }
    }
}
