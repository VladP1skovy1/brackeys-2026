using System;
using AntiqueShop.Utils;
using UnityEngine.Rendering.Universal;

namespace AntiqueShop.UI
{
    [Serializable]
    public struct LightPreset
    {
        public LightShapeType shapeType;
        public Light2D lightComponent;
    }
}