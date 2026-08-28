using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public bool IsActive { get; private set; }
        private Sprite _defaultSprite;

        public void SetupItem(Item itemData)
        {
            _defaultSprite = itemData.ItemSprite;
            spriteRenderer.sprite = _defaultSprite;
            IsActive = true;
            gameObject.SetActive(true);
            transform.position = _homePosition;
        }

        public void HideItem()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }

        public void Toggle(Sprite sprite)
        {
            if (sprite == null || spriteRenderer.sprite == sprite)
            {
                spriteRenderer.sprite = _defaultSprite;
                return;
            }

            spriteRenderer.sprite = sprite;
        }

        public bool TogglePosition(Vector3 position)
        {
            bool moving = transform.position != position;
            transform.position = moving ? position : _homePosition;
            return moving;
        }
    }
}
