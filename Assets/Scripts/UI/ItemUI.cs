using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetupItem(Item itemData)
        {
            spriteRenderer.sprite = itemData.ItemSprite;
            gameObject.SetActive(true);
        }

        public void HideItem()
        {
            gameObject.SetActive(false);
        }
    }
}
