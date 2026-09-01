using System;
using UnityEngine.Rendering.Universal;

namespace AntiqueShop.Lighting
{
    [Serializable]
    public struct LightPreset
    {
        public LightShapeType shapeType;
        public Light2D lightComponent;
    }
}