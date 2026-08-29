using System.Collections.Generic;
using AntiqueShop.Items;
using AntiqueShop.UI;
using AntiqueShop.Utils;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace AntiqueShop.Tools
{
    public class Lamp : Tool
    {
        [SerializeField] private Sprite idleSprite;
        [SerializeField] private Sprite uvSprite;

        [SerializeField] private List<Light2D> lampLights;
        [SerializeField] private Color idleLightColor;
        [SerializeField] private Color uvLightColor;

        [SerializeField] private ItemUI itemUI;
    
        private SpriteRenderer _spriteRenderer;
        private bool _isUvMode;
        
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        protected override void UpdateItem(Item item)
        {
            base.UpdateItem(item); 
            TurnOffUV(); 
        }

        private void TurnOffUV()
        {
            if (!_isUvMode) return;

            _isUvMode = false;
            _spriteRenderer.sprite = idleSprite;
            
            foreach (var light in lampLights)
            {
                light.color = idleLightColor;
            }
        }

        protected override void OnToolClick()
        {
            _isUvMode = !_isUvMode;
            _spriteRenderer.sprite = _isUvMode ? uvSprite : idleSprite;
            
            if (lampLights.Count > 0)
            {
                foreach (var light in lampLights)
                {
                    light.color = _isUvMode ? uvLightColor : idleLightColor;
                }
            }
            
            if (itemUI.IsActive && CurrentItem != null)
            {
                UpdateItemVisuals();
            }
        }
        
        private void UpdateItemVisuals()
        {
            Sprite spriteToShow = CurrentItem.ItemSprite;
            bool isGlow = false;
            
            if (_isUvMode && CurrentItem is IUVReactive { IsUVReactive: true } uvReactiveItem)
            {
                spriteToShow = uvReactiveItem.UVView;
                LightShapeType shapeType = uvReactiveItem.LightShape;
                Color glowColor = uvReactiveItem.GlowColor;
                itemUI.TurnOnLight(shapeType, glowColor);
                isGlow = true;
            }
            
            itemUI.ChangeSprite(spriteToShow);
            if (!isGlow)
            {
                itemUI.TurnOffAllLights();
            }
        }
    }
}