using UnityEngine;

namespace AntiqueShop
{
    public class CustomerUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void SetupCustomer(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
