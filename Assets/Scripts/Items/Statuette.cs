using AntiqueShop.Utils;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Statuette", menuName = "Scriptable Objects/Statuette")]
    public class Statuette : Item, IWeighable, IMagnetic, IUVReactive, IMeasurable
    {
        [field: SerializeField] public float Weight { get; private set; }
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
