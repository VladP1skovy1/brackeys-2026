using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Sprite _defaultSprite;
        private Vector3 _homePosition;

        private void Awake() => _homePosition = transform.position;

        public void SetupItem(Item itemData)
        {
            _defaultSprite = itemData.ItemSprite;
            spriteRenderer.sprite = _defaultSprite;
            gameObject.SetActive(true);
            transform.position = _homePosition;
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

        public bool TogglePosition(Vector3 position)
        {
            bool moving = transform.position != position;
            transform.position = moving ? position : _homePosition;
            return moving;
        }
    }
}
