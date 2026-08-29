using AntiqueShop.Utils;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Rock", menuName = "Scriptable Objects/Rock")]
    public class Rock : Item, IMagnetic, IUVReactive, IMeasurable
    {
        [field: SerializeField] public bool IsMagnetic { get; private set; }
        [field: SerializeField] public Vector2 Dimensions { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVRockSprite { get; private set; }
        [field: SerializeField] public LightShapeType LightShape { get; private set; }
        [field: SerializeField] public Color GlowColor { get; private set; }


        Sprite IUVReactive.UVView => UVRockSprite;
        LightShapeType IUVReactive.LightShape => LightShape;
        Color IUVReactive.GlowColor => GlowColor;
    }
}
