using System.Collections.Generic;
using AntiqueShop.Items;
using AntiqueShop.Utils;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<LightPreset> lightPresets;

        public bool IsActive { get; private set; }

        private Sprite _defaultSprite;
        private Vector3 _homePosition;

        private void Awake()
        {
            _homePosition = transform.position;
            TurnOffAllLights();
        }

        public void SetupItem(Item itemData)
        {
            _defaultSprite = itemData.ItemSprite;
            spriteRenderer.sprite = _defaultSprite;
            IsActive = true;
            gameObject.SetActive(true);
            transform.position = _homePosition;
            TurnOffAllLights();
        }
        
        public void TurnOnLight(LightShapeType shapeType, Color color = default)
        {
            foreach (var preset in lightPresets)
            {
                if (preset.shapeType != shapeType) continue;
                if (preset.lightComponent != null)
                {
                    preset.lightComponent.enabled = true;
                    preset.lightComponent.color = color;
                }
                break;
            }
        }

        public void TurnOffAllLights()
        {
            foreach (var preset in lightPresets)
            {
                if (preset.lightComponent)
                {
                    preset.lightComponent.enabled = false;
                }
            }
        }

        public void ChangeSprite(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }

        public void HideItem()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
        
    }
}
