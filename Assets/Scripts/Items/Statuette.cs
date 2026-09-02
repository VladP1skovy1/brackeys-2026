using AntiqueShop.Lighting;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Statuette", menuName = "Scriptable Objects/Statuette")]
    public class Statuette : Item, IMagnetic, IUVReactive, IMeasurable
    {
        [field: SerializeField] public bool IsMagnetic { get; private set; }
        [field: SerializeField] public Vector2 Dimensions { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVStatuetteSprite { get; private set; }
        [field: SerializeField] public LightShapeType LightShape { get; private set; }
        [field: SerializeField] public Color GlowColor { get; private set; }
        

        Sprite IUVReactive.UVView => UVStatuetteSprite;
        LightShapeType IUVReactive.LightShape => LightShape;
        Color IUVReactive.GlowColor => GlowColor;
    }
}
