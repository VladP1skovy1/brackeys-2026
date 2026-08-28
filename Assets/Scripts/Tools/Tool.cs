using AntiqueShop.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AntiqueShop.Tools
{
    public abstract class Tool : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] public Sprite ToolSprite { get; private set; }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                UseToolClick();
            }
        }
        
        protected abstract void UseToolClick();

        public abstract object Read(Item item);
    }
}
