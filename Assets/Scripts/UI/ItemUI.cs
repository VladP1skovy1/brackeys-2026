using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Sprite _defaultSprite;

        public void SetupItem(Item itemData)
        {
            _defaultSprite = itemData.ItemSprite;
            spriteRenderer.sprite = _defaultSprite;
            gameObject.SetActive(true);
        }

        public void HideItem()
        {
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
    }
}
